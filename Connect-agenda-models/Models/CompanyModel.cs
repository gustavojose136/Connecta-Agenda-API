using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class CompanyModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string AddressId { get; set; }
        public AddresModel Address { get; set; }
        public string OnwerId { get; set; }
        public UserModel Onwer { get; set; }
        public string UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
