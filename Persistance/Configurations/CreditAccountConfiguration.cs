using Domain.Entities;
using Domain.Entities.Accounts;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CreditAccountConfiguration : IEntityTypeConfiguration<CreditAccount>
    {
        public void Configure(EntityTypeBuilder<CreditAccount> builder)
        {
            builder.HasKey(ca => ca.Id);

            builder.Property(ca => ca.Balance)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ca => ca.IsLocked)
                   .IsRequired();

            builder.Property(ca => ca.CreditLimit)
                   .IsRequired();

            builder.Property(ca => ca.InterestRate)
                   .HasColumnType("REAL") // SQLite использует REAL для float
                   .IsRequired();

            builder.Property(ca => ca.CreditEndDate)
                   .IsRequired();

            // Связь с владельцем счета
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(ca => ca.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict); // Удаление владельца не удаляет счёт
        }
    }
}
