using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.FilterModels
{
    public class ServiceFilterModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CompanyId { get; set; }
        public bool? IsActive { get; set; }
    }
}
