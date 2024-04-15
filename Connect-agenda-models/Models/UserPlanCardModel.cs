using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class UserPlanCardModel
    {
        public string Id { get; set; }
        public string IdPlanCard { get; set; }
        public PlanCardModel PlanCard { get; set; }
        public string IdUser { get; set; }
        public UserModel User { get; set; }
        public string PlanCardNumber { get; set; }
        public bool IsActive { get; set; }
        public string? UserUpdateId { get; set; }
        public UserModel? UserUpdate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserCreatedId { get; set; }
        public UserModel UserCreated { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
