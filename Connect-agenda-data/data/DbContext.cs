using Connect_agenda_data.data.Map;
using Connect_agenda_models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.data
{
    public class ConnectAgendaContext : DbContext
    {
        public ConnectAgendaContext(DbContextOptions<ConnectAgendaContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<AddresModel> Address { get; set; }
        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<LogsModel> Logs { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<PlanCardModel> PlanCard { get; set; }
        public DbSet<ProfissionalServiceModel> ProfissionalService { get; set; }
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<RoleUserCompanyModel> RoleUserCompany { get; set; }
        public DbSet<ServiceModel> Service { get; set; }
        public DbSet<SpecialitsModel> Specialits { get; set; }
        public DbSet<UserCompanyModel> UserCompany { get; set; }
        public DbSet<UserPlanCardModel> UserPlanCard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new LogsMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new PlanCardMap());
            modelBuilder.ApplyConfiguration(new ProfissionalServiceMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RoleUserCompanyMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new SpecialitsMap());
            modelBuilder.ApplyConfiguration(new UserCompanyMap());
            modelBuilder.ApplyConfiguration(new UserPlanCardMap());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
