using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class RoleUserCompanyRepository : IRoleUserCompanyRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public RoleUserCompanyRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<RoleUserCompanyModel> Post(RoleUserCompanyModel roleUserCompany)
        {
            try
            {
                await _dBContext.RoleUserCompany.AddAsync(roleUserCompany);
                await _dBContext.SaveChangesAsync();

                return roleUserCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
