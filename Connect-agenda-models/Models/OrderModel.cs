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
        public string ProfissionalServiceId { get; set; } = string.Empty;
        public ProfissionalServiceModel ProfissionalService { get; set; } = new ProfissionalServiceModel();
        public string ClientId { get; set; } = string.Empty;
        public UserModel Client { get; set; } = new UserModel();
        public string CompanyId { get; set; } = string.Empty;
        public CompanyModel Company { get; set; } = new CompanyModel();
        public string Observation { get; set; } = string.Empty;
        public OrderStatusEnumModel Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PaymentMethodEnum paymentMethod { get; set; }
        public string? PlanCardId { get; set; }
        public PlanCardModel? PlanCard { get; set; }
        public double Price { get; set; }
        public double Discont { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPlanCoop { get;set; }
        public double? PricePlanCoop { get; set; }
        public string UserUpdateId { get; set; } = string.Empty;
        public UserModel UserUpdate { get; set; } = new UserModel();
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; } = string.Empty;
        public UserModel UserCreate { get; set; } = new UserModel();
        public DateTime CreateDate { get; set; }
    }
}
