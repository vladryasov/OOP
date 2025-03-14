using Domain.Entities;
using Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class BaseAccountConfiguration : IEntityTypeConfiguration<BaseAccount>
    {
        public void Configure(EntityTypeBuilder<BaseAccount> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Balance)
                .HasColumnType("decimal(18,2)");


            builder.HasMany<MyTransaction>()
                .WithOne()
                .HasForeignKey(e => e.FromId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

