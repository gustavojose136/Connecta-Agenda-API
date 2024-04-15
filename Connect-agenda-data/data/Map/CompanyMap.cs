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
    public class CompanyMap : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Email);
            builder.Property(u => u.Cnpj).IsRequired();
            builder.Property(u => u.Image).IsRequired();
            builder.Property(u => u.Phone).IsRequired();
            builder.Property(u => u.AddressId).IsRequired();
            builder.Property(u => u.OnwerId).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.UserUpdateId).IsRequired();
            builder.Property(u => u.UpdateDate).IsRequired();
            builder.Property(u => u.UserCreateId).IsRequired();
            builder.Property(u => u.CreateDate).IsRequired();

            builder.HasOne(u => u.Address)
                    .WithMany()
                    .HasForeignKey(p => p.AddressId)
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
