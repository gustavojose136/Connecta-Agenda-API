using Connect_agenda_data.repository;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_services.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserCompanyRepository _userCompanyRepository;

        public CompanyService(ICompanyRepository companyRepository, IUserCompanyRepository userCompanyRepository)
        {
            _companyRepository = companyRepository;
            _userCompanyRepository = userCompanyRepository;
        }

        public async Task<List<CompanyModel>> GetAll()
        {
            try
            {
                return await _companyRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanyModel> GetById(string id)
        {
            try
            {
                return await _companyRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public async Task<CompanyModel> Add(CompanyModel company, string userId)
        {
            try
            {
                company.OnwerId = userId;
                company.IsActive = true;


                company.UserCreateId = userId;
                company.UserUpdateId = userId;
                company.CreateDate = DateTime.Now;
                company.UpdateDate = DateTime.Now;
                
                return await _companyRepository.Add(company);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanyModel> Update(CompanyModel company, string userId)
        {
            try
            {
                company.UserUpdateId = userId;
                company.UpdateDate = DateTime.Now;

                return await _companyRepository.Update(company);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanyModel> Inactive(string id, string userId)
        {
            try
            {
                var company = await _companyRepository.GetById(id);

                if (company == null) throw new Exception("Empresa não encontrada");

                company.IsActive = false;
                company.UserUpdateId = userId;
                company.UpdateDate = DateTime.Now;

                await InactiveAllUserCompanys(userId, company.Id);

                return await _companyRepository.Update(company);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<List<UserCompanyModel>> InactiveAllUserCompanys(string userUpdateId, string companyId)
        {
            try
            {
                UserCompanyFilterModel userCompanyFilter = new UserCompanyFilterModel();
                userCompanyFilter.CompanyId = companyId;

                var userCompanys = await _userCompanyRepository.GetAll(userCompanyFilter);

                for (int i = 0; i < userCompanys.Count; i++)
                {
                    userCompanys[i].IsActive = false;
                    userCompanys[i].UpdateDate = DateTime.Now;
                    userCompanys[i].UserUpdateId = userUpdateId;

                    await _userCompanyRepository.Update(userCompanys[i]);
                }

                return userCompanys;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
