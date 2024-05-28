using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public CompanyRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<List<CompanyModel>> GetAll()
        {
            try
            {
                return await _dBContext.Company.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<CompanyModel> GetById(string id)
        {
            try
            {
                return _dBContext.Company.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanyModel> Add(CompanyModel company)
        {
            try
            {
                await _dBContext.Company.AddAsync(company);
                await _dBContext.SaveChangesAsync();

                return company;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanyModel> Update(CompanyModel company)
        {
            try 
            { 
                _dBContext.Company.Update(company);
                await _dBContext.SaveChangesAsync();

                return company;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CompanyModel> Inactive(string id)
        {
            try
            {
                var company = _dBContext.Company.FirstOrDefault(x => x.Id == id);

                if(company == null)
                    throw new Exception("Empresa Não Encontrada");

                company.IsActive = false;

                _dBContext.Company.Update(company);
                await _dBContext.SaveChangesAsync();

                return company;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var company = _dBContext.Company.FirstOrDefault(x => x.Id == id);

                if (company == null)
                    throw new Exception("Empresa Não Encontrada");

                _dBContext.Company.Remove(company);
                await _dBContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
