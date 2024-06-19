using Connect_agenda_models.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.FilterModels
{
    public class OrderFilterModel
    {
        public string? Id { get; set; }
        public string? ProfissionalServiceId { get; set; }
        public string? ClientId { get; set; }
        public OrderStatusEnumModel? Status { get; set; }
        public string? CompanyId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PaymentMethodEnum paymentMethod { get; set; }
        public string? PlanCardId { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPlanCoop { get; set; }
    }
}
