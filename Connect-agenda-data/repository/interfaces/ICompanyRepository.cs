using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface ICompanyRepository
    {
        public Task<List<CompanyModel>> GetAll();
        public Task<CompanyModel> GetById(string id);
        public Task<CompanyModel> Add(CompanyModel company);
        public Task<CompanyModel> Update(CompanyModel company);
        public Task<CompanyModel> Inactive(string id);
        public Task<bool> Delete(string id);
    }
}
