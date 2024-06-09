using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class AdrressRepository : IAdrressRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public AdrressRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }


        public async Task<AddressExitModel> GetAll(AddressFilterModel filter, int pageNumber, int pageItems)
        {
            try
            {
                AddressExitModel exit = new AddressExitModel();

                var query = _dBContext.Address.AsQueryable();

                if (!string.IsNullOrEmpty(filter.Id))
                    query = query.Where(x => x.Id == filter.Id);

                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(x => x.Name.Contains(filter.Name));

                if (!string.IsNullOrEmpty(filter.Street))
                    query = query.Where(x => x.Street.Contains(filter.Street));


                exit.Total = await query.CountAsync();

                query = query
                    .Include(x => x.UserUpdate)
                    .Include(x => x.UserCreate);

                exit.Address = await query.ToListAsync();

                return exit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AddresModel> Post(AddresModel model)
        {
            try
            {
                await _dBContext.Address.AddAsync(model);
                await _dBContext.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<AddressExitModel> Update(AddressFilterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AddressExitModel> Inactive(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressExitModel> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
