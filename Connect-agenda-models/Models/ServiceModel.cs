
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class ServiceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string CompanyId { get; set; }
        public CompanyModel Company { get; set; }
        public string UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
