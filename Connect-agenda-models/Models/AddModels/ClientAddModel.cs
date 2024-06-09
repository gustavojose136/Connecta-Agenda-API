using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.AddModels
{
    public class ClientAddModel
    {
        public Client ClientData { get; set; } = new Client();
        public ClientAddres ClientAddres { get; set; } = new ClientAddres();
        public List<ClientPlans>? ClientPlans { get; set; }
    }

    public class Client
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
    }

    public class ClientAddres
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

    public class ClientPlans
    {
        public string IdPlanCard { get; set; } = "";
        public string PlanCardNumber { get; set; } = "";
    }
}
