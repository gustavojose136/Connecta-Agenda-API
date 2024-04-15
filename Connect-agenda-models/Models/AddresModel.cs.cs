using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class AddresModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Observation { get; set; }
        public bool IsActive { get; set; }
        public string UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
