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
    public class RoleUserCompanyMap : IEntityTypeConfiguration<RoleUserCompanyModel>
    {
        public void Configure(EntityTypeBuilder<RoleUserCompanyModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.UserCompanyId).IsRequired();
            builder.Property(u => u.WorksDays);
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.UserUpdateId);
            builder.Property(u => u.UpdateDate);
            builder.Property(u => u.UserCreateId).IsRequired();
            builder.Property(u => u.CreateDate).IsRequired();

            builder.HasOne(u => u.Role)
                    .WithMany()
                    .HasForeignKey(p => p.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UserCompany)
                    .WithMany()
                    .HasForeignKey(p => p.UserCompanyId)
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
