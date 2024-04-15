using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.ExitModels
{
    public class UserExitModel
    {
        public List<UserModel>? Users { get; set; }
        public int Total { get; set; }
    }
}
