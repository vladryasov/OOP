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

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.Owner)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

public class EnterpriseAccountConfiguration : IEntityTypeConfiguration<EnterpriseAccount>
{
    public void Configure(EntityTypeBuilder<EnterpriseAccount> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Balance)
            .HasColumnType("decimal(18,2)");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.Owner)
            .OnDelete(DeleteBehavior.Cascade);
    }
}