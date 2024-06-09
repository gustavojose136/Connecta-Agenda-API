using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.AddModels
{
    public class UserAddModel
    {
        public string? Name { get; set; }
        public string? SocialName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsAdmin { get; set; }
        public Byte[]? Image { get; set; }
        public string? AddresId { get; set; }
    }
}
