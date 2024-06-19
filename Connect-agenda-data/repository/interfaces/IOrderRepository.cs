using Connect_agenda_models.Models;
using Connect_agenda_models.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface IOrderRepository
    {
        public Task<List<OrderModel>> GetAllOrders(string? CompanyId);
        public Task<List<OrderModel>> GetOrderByFilter(OrderFilterModel filter);
        public Task<OrderModel> Post(OrderModel order);
    }
}
