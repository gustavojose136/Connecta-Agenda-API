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
    public class RoleRepository : IRoleRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public RoleRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<RoleModel> GetProfissionalRole(string companyId)
        {
            try
            {
                return await _dBContext.Role
                                        .FirstOrDefaultAsync(x =>
                                            x.CompanyId == companyId &&
                                            x.Name.Contains("Profissional")
                                         );
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
