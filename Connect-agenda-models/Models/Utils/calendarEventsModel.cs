using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.Utils
{
    public class calendarEventsModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; } 
        public DateTime? End { get; set; }
        public string ClassName { get; set; } = string.Empty;
    }
}
