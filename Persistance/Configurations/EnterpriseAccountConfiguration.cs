using Domain.Entities.Accounts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class EnterpriseAccountConfiguration : IEntityTypeConfiguration<EnterpriseAccount>
    {
        public void Configure(EntityTypeBuilder<EnterpriseAccount> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Balance)
                .HasColumnType("decimal(18,2)");

            builder.HasMany<MyTransaction>()
                .WithOne()
                .HasForeignKey(e => e.FromId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
