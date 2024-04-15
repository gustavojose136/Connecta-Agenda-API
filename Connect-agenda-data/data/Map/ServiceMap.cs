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
    public class ServiceMap : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Description);
            builder.Property(u => u.Price).IsRequired();
            builder.Property(u => u.Duration).IsRequired();
            builder.Property(u => u.Image).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.CompanyId).IsRequired();
            builder.Property(u => u.UserUpdateId).IsRequired();
            builder.Property(u => u.UpdateDate).IsRequired();
            builder.Property(u => u.UserCreateId).IsRequired();
            builder.Property(u => u.CreateDate).IsRequired();

            builder.HasOne(u => u.Company)
                    .WithMany()
                    .HasForeignKey(p => p.CompanyId)
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
