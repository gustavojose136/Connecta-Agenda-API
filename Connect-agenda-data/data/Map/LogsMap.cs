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
    public class LogsMap : IEntityTypeConfiguration<LogsModel>
    {
        public void Configure(EntityTypeBuilder<LogsModel> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Type).IsRequired();
            builder.Property(u => u.Module);
            builder.Property(u => u.Message).IsRequired();
            builder.Property(u => u.Status).IsRequired();
            builder.Property(u => u.Date).IsRequired();

            builder.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
