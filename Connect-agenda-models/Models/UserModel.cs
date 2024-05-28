using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models
{
    public class UserModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? SocialName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAdmin { get; set; }
        public Byte[]? Image { get; set; }
        public string? AddresId { get; set; }
        public AddresModel? Addres { get; set; }
        public string? UserUpdateId { get; set; }
        public UserModel? UserUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCreateId { get; set; }
        public UserModel? UserCreate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
