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
    public class UserPlanCardMap : IEntityTypeConfiguration<UserPlanCardModel>
    {
        public void Configure(EntityTypeBuilder<UserPlanCardModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.IdPlanCard).IsRequired();
            builder.Property(u => u.IdUser).IsRequired();
            builder.Property(u => u.PlanCardNumber).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.UserUpdateId);
            builder.Property(u => u.UpdatedAt);
            builder.Property(u => u.UserCreatedId).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();


            builder.HasOne(u => u.PlanCard)
                    .WithMany()
                    .HasForeignKey(p => p.IdPlanCard)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.User)
                .WithMany()
                    .HasForeignKey(p => p.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UserUpdate)
                .WithMany()
                    .HasForeignKey(p => p.UserUpdateId)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(u => u.UserCreated)
                .WithMany()
                    .HasForeignKey(p => p.UserCreatedId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}