using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class PorfissionalServiceModel
    {
        public Guid Id { get; set; }
        public Guid ProfissionalId { get; set; }
        public UserCompanyModel Profissional { get; set; }
        public Guid ServiceId { get; set; }
        public ServiceModel Service { get; set; }
        public double Price { get; set; }   
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }
        public Guid UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
