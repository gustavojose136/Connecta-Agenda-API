using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models.FilterModels;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;

namespace Connect_agenda_services.Services
{
    public class ScheduleService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public ScheduleService(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderModel>> getAll(OrderFilterModel filter, string companyId)
        {
            try
            {
                filter.CompanyId = companyId;
                
                return await _orderRepository.GetOrderByFilter(filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> CreateSchedule(OrderAddModel orderAdd, string companyId, string userCreateId)
        {
            try
            {
                var havSchedule = await HaveAnyScheduleForProfissional(orderAdd.ProfissionalServiceId, orderAdd.StartDate, orderAdd.EndDate);
                
                if (havSchedule)
                    throw new Exception("Já existe um agendamento para este profissional neste horário, por favor escolha outro horário.");
                
                OrderModel order = new OrderModel();

                order.ProfissionalServiceId = orderAdd.ProfissionalServiceId;
                order.ClientId = orderAdd.ClientId;
                order.CompanyId = companyId;
                order.Observation = orderAdd.Observation;
                order.Status = orderAdd.Status;
                order.StartDate = orderAdd.StartDate;
                order.EndDate = orderAdd.EndDate;
                order.paymentMethod = orderAdd.paymentMethod;
                order.PlanCardId = orderAdd.PlanCardId;
                order.Price = orderAdd.Price;
                order.Discont = orderAdd.Discont;
                order.IsPaid = orderAdd.IsPaid;
                order.IsPlanCoop = orderAdd.IsPlanCoop;
                order.PricePlanCoop = orderAdd.PricePlanCoop;
                order.UserUpdateId = userCreateId;
                order.UpdateDate = DateTime.Now;
                order.UserCreateId = userCreateId;
                order.CreateDate = DateTime.Now;

                await _orderRepository.Post(order);

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Método para verificar se já existe um agendamento para o profissional no horário escolhido
        // Adicoinar Regra para pegar a configuração de horário do profissional
        public async Task<bool> HaveAnyScheduleForProfissional(string profissinalId, DateTime startDate, DateTime? endDate)
        {
            try
            {
                OrderFilterModel filter = new OrderFilterModel();
                filter.ProfissionalServiceId = profissinalId;
                filter.StartDate = startDate;
                filter.EndDate = endDate ?? DateTime.Now;

                var orders = await _orderRepository.GetOrderByFilter(filter);

                return orders.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
