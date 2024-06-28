using Connect_agenda_models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.AddModels
{
    public class OrderAddModel
    {
        public string ProfissionalServiceId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public OrderStatusEnumModel Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PaymentMethodEnum paymentMethod { get; set; }
        public string? PlanCardId { get; set; }
        public double Price { get; set; }
        public double? Discont { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPlanCoop { get; set; }
        public double? PricePlanCoop { get; set; }
    }
}
