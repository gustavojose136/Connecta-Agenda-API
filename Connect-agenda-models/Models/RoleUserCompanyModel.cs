using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class RoleUserCompanyModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RoleId { get; set; }
        public RoleModel Role { get; set; }
        public string UserCompanyId { get; set; }
        public UserCompanyModel UserCompany { get; set; }
        public string WorksDays { get; set; }
        public bool IsActive { get; set; }
        public string UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
