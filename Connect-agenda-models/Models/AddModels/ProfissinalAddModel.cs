using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.AddModels
{
    public class ProfissinalAddModel
    {
        public Profissional ProfissionalData { get; set; } = new Profissional();
        public ProfissionalAddres ProfissionalAddres { get; set; } = new ProfissionalAddres();
        public List<ProfissionalServiceShortModel>? ProfissionalServices { get; set; }
    }

    public class Profissional
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
        public string? WorksDays { get; set; }
    }

    public class ProfissionalAddres
    {
        public string Name { get; set; } = "";
        public string Street { get; set; } = "";
        public string? Neighborhood { get; set; }
        public string Number { get; set; } = "";
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public string? Observation { get; set; }
    }

    public class ProfissionalServiceShortModel
    {
        public string? ServiceId { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
    }
}
