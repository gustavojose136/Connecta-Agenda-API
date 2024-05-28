using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class PorfissionalServiceModel
    {
        public string Id { get; set; }
        public string ProfissionalId { get; set; }
        public UserCompanyModel Profissional { get; set; }
        public string ServiceId { get; set; }
        public ServiceModel Service { get; set; }
        public double Price { get; set; }   
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public bool IsActive { get; set; }
        public string UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
