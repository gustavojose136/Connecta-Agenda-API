using Connect_agenda_models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class OrderModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProfissionalServiceId { get; set; }
        public ProfissionalServiceModel ProfissionalService { get; set; }
        public string ClientId { get; set; }
        public UserModel Client { get; set; }
        public string Observation { get; set; }
        public OrderStatusEnumModel Status { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethodEnum paymentMethod { get; set; }
        public string? PlanCardId { get; set; }
        public PlanCardModel? PlanCard { get; set; }
        public double Price { get; set; }
        public double Discont { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPlanCoop { get;set; }
        public double? PricePlanCoop { get; set; }
        public string UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
