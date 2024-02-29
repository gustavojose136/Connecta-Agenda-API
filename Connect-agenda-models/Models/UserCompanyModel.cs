using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class UserCompanyModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyModel Company { get; set; }
        public Guid RoleUserCompanyId { get; set; }
        public RoleUserCompanyModel RoleUserCompany { get; set; }
        public bool IsActive { get; set; }
        public Guid UserUpdateId { get; set; }
        public UserModel UserUpdate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UserCreateId { get; set; }
        public UserModel UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
