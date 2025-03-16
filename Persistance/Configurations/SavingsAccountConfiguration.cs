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
    public class SavingsAccountConfiguration : IEntityTypeConfiguration<SavingsAccount>
    {
        public void Configure(EntityTypeBuilder<SavingsAccount> builder)
        {
            builder.HasKey(ca => ca.Id);

            builder.Property(ca => ca.Balance)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ca => ca.IsLocked)
                   .IsRequired();

            builder.Property(ca => ca.InterestRate)
                   .HasColumnType("REAL") // SQLite использует REAL для float
                   .IsRequired();

            builder.HasMany<MyTransaction>()
                .WithOne()
                .HasForeignKey(e => e.FromId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
