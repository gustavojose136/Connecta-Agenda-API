using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface IRoleUserCompanyRepository
    {
        public Task<RoleUserCompanyModel> Post(RoleUserCompanyModel roleUserCompany);
    }
}
