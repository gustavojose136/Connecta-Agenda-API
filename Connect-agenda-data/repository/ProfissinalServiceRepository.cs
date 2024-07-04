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
    public class ProfissinalServiceRepository : IProfissinalServiceRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public ProfissinalServiceRepository(ConnectAgendaContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<ProfissionalServiceModel>> GetAll()
        {
            try
            {
                return await _dBContext.ProfissionalService
                    .Include(x => x.Profissional)
                    .ThenInclude(x => x.User)
                    .Include(x => x.Service)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfissionalServiceModel> GetById(string profissionalId)
        {
            try
            {
                return await _dBContext.ProfissionalService.FindAsync(profissionalId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfissionalServiceModel> Post(ProfissionalServiceModel profissionalService)
        {
            try
            {
                await _dBContext.ProfissionalService.AddAsync(profissionalService);
                await _dBContext.SaveChangesAsync();

                return profissionalService;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
