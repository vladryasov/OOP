using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.UserId)
                   .IsRequired();

            builder.Property(l => l.SumOfLoan)
                   .HasColumnType("decimal(18,2)") // Корректный формат для денежных операций
                   .IsRequired();

            builder.Property(l => l.EndDate)
                   .IsRequired();

            builder.Property(l => l.InterestRate)
                   .HasColumnType("REAL") // SQLite использует REAL для float
                   .IsRequired();

            builder.Property(l => l.IsApproved)
                   .HasDefaultValue(false); // По умолчанию кредит не утверждён

            // Связь 1 ко многим: User → Loan
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(l => l.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // При удалении пользователя удаляем его кредиты
        }
    }
}
