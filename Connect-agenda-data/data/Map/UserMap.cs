using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect_agenda_models.Models;

namespace Connect_agenda_data.data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.SocialName);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Gender);
            builder.Property(u => u.Phone).IsRequired();
            builder.Property(u => u.Cpf).IsRequired();
            builder.Property(u => u.Rg);
            builder.Property(u => u.BirthDate).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsAdmin).IsRequired();
            builder.Property(u => u.Image);
            builder.Property(u => u.AddresId).IsRequired();
            builder.Property(u => u.Phone).IsRequired();
            builder.Property(u => u.UserUpdateId);
            builder.Property(u => u.UpdateDate).IsRequired();
            builder.Property(u => u.UserCreateId);
            builder.Property(u => u.CreateDate).IsRequired();

            builder.HasOne(u => u.Addres)
                                .WithMany()
                                .HasForeignKey(r => r.AddresId)
                                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UserCreate)
                                .WithMany()
                                .HasForeignKey(r => r.UserCreateId)
                                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UserUpdate)
                                .WithMany()
                                .HasForeignKey(r => r.UserUpdateId)
                                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
