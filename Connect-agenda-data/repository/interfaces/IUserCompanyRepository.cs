using Connect_agenda_models.Models;
using Connect_agenda_models.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface IUserCompanyRepository
    {
        public Task<List<UserCompanyModel>> GetAll(UserCompanyFilterModel filter);

        public Task<UserCompanyModel> GetById(string id);
        public Task<UserCompanyModel> GetByUserId(string userId);

        public Task<UserCompanyModel> Add(UserCompanyModel userCompany);

        public Task<UserCompanyModel> Update(UserCompanyModel userCompany);

        public Task<UserCompanyModel> Inactive(string id);

        public Task<bool> Delete(string id);
    }
}
