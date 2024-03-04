using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class LogsModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Module { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
        public string? Status { get; set; }
        public DateTime Date { get; set; }
    }
}
