using Connect_agenda_models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.data.Map
{
    public class OrderMap : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.ProfissionalServiceId).IsRequired();
            builder.Property(u => u.ClientId).IsRequired();
            builder.Property(u => u.CompanyId).IsRequired();
            builder.Property(u => u.Observation);
            builder.Property(u => u.Status).IsRequired();
            builder.Property(u => u.StartDate).IsRequired();
            builder.Property(u => u.EndDate).IsRequired();
            builder.Property(u => u.paymentMethod).IsRequired();
            builder.Property(u => u.PlanCardId);
            builder.Property(u => u.Price).IsRequired();
            builder.Property(u => u.Discont).IsRequired();
            builder.Property(u => u.IsPaid).IsRequired();
            builder.Property(u => u.IsPlanCoop).IsRequired();
            builder.Property(u => u.PricePlanCoop);
            builder.Property(u => u.UserUpdateId).IsRequired();
            builder.Property(u => u.UpdateDate).IsRequired();
            builder.Property(u => u.UserCreateId).IsRequired();
            builder.Property(u => u.CreateDate).IsRequired();

            builder.HasOne(u => u.ProfissionalService)
                    .WithMany()
                    .HasForeignKey(p => p.ProfissionalServiceId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Client)
                    .WithMany()
                    .HasForeignKey(p => p.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Company)
                    .WithMany()
                    .HasForeignKey(p => p.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.PlanCard)
                    .WithMany()
                    .HasForeignKey(p => p.PlanCardId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UserUpdate)
                    .WithMany()
                    .HasForeignKey(p => p.UserUpdateId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UserCreate)
                    .WithMany()
                    .HasForeignKey(p => p.UserCreateId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
