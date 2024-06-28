using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.FilterModels;
using Microsoft.EntityFrameworkCore;

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
                {
                    query = query.Where(x => x.Id == filter.Id);
                    Console.WriteLine("Filter applied: Id");
                }

                if (!string.IsNullOrEmpty(filter.ProfissionalServiceId))
                {
                    query = query.Where(x => x.ProfissionalServiceId == filter.ProfissionalServiceId);
                    Console.WriteLine("Filter applied: ProfissionalServiceId");
                }

                if (!string.IsNullOrEmpty(filter.ClientId))
                {
                    query = query.Where(x => x.ClientId == filter.ClientId);
                    Console.WriteLine("Filter applied: ClientId");
                }

                if (filter.Status != null)
                {
                    query = query.Where(x => x.Status == filter.Status);
                    Console.WriteLine("Filter applied: Status");
                }

                // if (!string.IsNullOrEmpty(filter.CompanyId))
                // {
                //     query = query.Where(x => x.CompanyId == filter.CompanyId);
                //     Console.WriteLine("Filter applied: CompanyId");
                // }

                if (filter.StartDate != null)
                {
                    query = query.Where(x => x.StartDate >= filter.StartDate);
                    Console.WriteLine("Filter applied: StartDate");
                }

                if (filter.EndDate != null)
                {
                    query = query.Where(x => x.EndDate <= filter.EndDate);
                    Console.WriteLine("Filter applied: EndDate");
                }

                //if (filter.paymentMethod != null)
                //{
                //    query = query.Where(x => x.paymentMethod == filter.paymentMethod);
                //    Console.WriteLine("Filter applied: paymentMethod");
                //}

                if (!string.IsNullOrEmpty(filter.PlanCardId))
                {
                    query = query.Where(x => x.PlanCardId == filter.PlanCardId);
                    Console.WriteLine("Filter applied: PlanCardId");
                }

                //if (filter.IsPaid != null)
                //{
                //    query = query.Where(x => x.IsPaid == filter.IsPaid);
                //    Console.WriteLine("Filter applied: IsPaid");
                //}

                if (filter.IsPlanCoop)
                {
                    query = query.Where(x => x.IsPlanCoop == filter.IsPlanCoop);
                    Console.WriteLine("Filter applied: IsPlanCoop");
                }

                query = query
                    .Include(x => x.Client)
                    .Include(x => x.ProfissionalService)
                    .ThenInclude(x => x.Profissional);

                var result = await query.ToListAsync();
                Console.WriteLine($"Number of records found: {result.Count}");

                return result;
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

        public Task<OrderModel> Update(OrderModel order)
        {
            try
            {
                _dBContext.Order.Update(order);
                _dBContext.SaveChanges();

                return Task.FromResult(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
