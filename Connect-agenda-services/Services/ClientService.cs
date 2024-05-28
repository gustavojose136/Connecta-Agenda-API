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
    public class ClientService
    {
        private readonly IUserCompanyRepository _userCompanyRepository;

        public ClientService(IUserCompanyRepository userCompanyRepository) 
        {
            _userCompanyRepository = userCompanyRepository;
        }

        public async Task<List<UserCompanyModel>> getAll(UserCompanyFilterModel filter, string companyId)
        {
            try
            {
                filter.CompanyId = companyId;

                var clients = await _userCompanyRepository.GetAll(filter);

                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
