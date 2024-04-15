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
    public class AddressMap : IEntityTypeConfiguration<AddresModel>
    {
        public void Configure(EntityTypeBuilder<AddresModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Street).IsRequired();
            builder.Property(u => u.Neighborhood).IsRequired();
            builder.Property(u => u.Number).IsRequired();
            builder.Property(u => u.City).IsRequired();
            builder.Property(u => u.ZipCode).IsRequired();
            builder.Property(u => u.State).IsRequired();
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.Observation).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.UserUpdateId);
            builder.Property(u => u.UpdateDate);
            builder.Property(u => u.UserCreateId);
            builder.Property(u => u.CreateDate).IsRequired();

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
