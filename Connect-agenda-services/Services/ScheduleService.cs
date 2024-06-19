using Connect_agenda_data.repository;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models.FilterModels;
using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<UserCompanyModel>> getAll(OrderFilterModel filter, string companyId)
        {
            try
            {
                filter.CompanyId = companyId;

                //var clients = await _userCompanyRepository.GetAll(filter);

                return new List<UserCompanyModel>();
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
    }
}
