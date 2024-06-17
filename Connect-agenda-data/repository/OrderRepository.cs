using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.ExitModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public OrderRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<List<OrderModel>> GetAllOrders(string? CompanyId)
        {
            try
            {
                AddressExitModel exit = new AddressExitModel();

                var query = _dBContext.Order.AsQueryable();

                if (!string.IsNullOrEmpty(CompanyId))
                    query = query.Where(x => x.CompanyId == CompanyId);

                query = query
                    .Include(x => x.ProfissionalService)
                    .ThenInclude(x => x.Profissional);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> Post(OrderModel order)
        {
            try
            {
                await _dBContext.Order.AddAsync(order);
                await _dBContext.SaveChangesAsync();

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
