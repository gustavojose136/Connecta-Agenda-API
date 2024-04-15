using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.FilterModels
{
    public class UserFilterModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? SocialName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAdmin { get; set;}
    }
}
