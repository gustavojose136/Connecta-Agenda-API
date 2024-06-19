using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.Enums;
using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
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

        public async Task<List<OrderModel>> GetOrderByFilter(OrderFilterModel filter)
        {
            try
            {
                var query = _dBContext.Order.AsQueryable();

                if (!string.IsNullOrEmpty(filter.Id))
                    query = query.Where(x => x.Id == filter.Id);

                if (!string.IsNullOrEmpty(filter.ProfissionalServiceId))
                    query = query.Where(x => x.ProfissionalServiceId == filter.ProfissionalServiceId);

                if (!string.IsNullOrEmpty(filter.ClientId))
                    query = query.Where(x => x.ClientId == filter.ClientId);

                if (filter.Status != null)
                    query = query.Where(x => x.Status == filter.Status);

                if (!string.IsNullOrEmpty(filter.CompanyId))
                    query = query.Where(x => x.CompanyId == filter.CompanyId);

                if (filter.StartDate != null)
                    query = query.Where(x => x.StartDate >= filter.StartDate);

                if (filter.EndDate != null)
                    query = query.Where(x => x.EndDate <= filter.EndDate);

                if (filter.paymentMethod != null)
                    query = query.Where(x => x.paymentMethod == filter.paymentMethod);

                if (!string.IsNullOrEmpty(filter.PlanCardId))
                    query = query.Where(x => x.PlanCardId == filter.PlanCardId);

                if (filter.IsPaid != null)
                    query = query.Where(x => x.IsPaid == filter.IsPaid);

                if (filter.IsPlanCoop)
                    query = query.Where(x => x.IsPlanCoop == filter.IsPlanCoop);

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
