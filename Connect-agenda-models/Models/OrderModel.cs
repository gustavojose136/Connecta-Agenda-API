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
        public Guid Id { get; set; }
        public Guid ProfissionalServiceId { get; set; }
        public PorfissionalServiceModel ProfissionalService { get; set; }
        public Guid ClientId { get; set; }
        public UserModel Client { get; set; }
        public string Observation { get; set; }
        public OrderStatusEnumModel Status { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethodEnum paymentMethod { get; set; }
        public Guid PlanCardId { get; set; }
        public PlanCardModel PlanCard { get; set; }
        public double Price { get; set; }
        public double Discont { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPlanCoop { get;set; }
        public Guid UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
