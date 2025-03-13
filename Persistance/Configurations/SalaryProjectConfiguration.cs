using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Persistence.Configurations
{
    public class SalaryProjectConfiguration : IEntityTypeConfiguration<SalaryProject>
    {
        public void Configure(EntityTypeBuilder<SalaryProject> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.EnterpriseAccountId)
                   .IsRequired();

            builder.Property(sp => sp.BankId)
                   .IsRequired();

            builder.Property(sp => sp.IsApproved)
                   .HasDefaultValue(false);

            builder.Property(sp => sp.Salary)
                   .HasColumnType("decimal(18,2)");

            // Храним список ID счетов сотрудников как JSON
            builder.Property(sp => sp.EmployeeAccountsIds)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions?)null) ?? new List<int>()
                   )
                   .HasColumnType("TEXT"); // SQLite не поддерживает JSON, используем TEXT
        }
    }
}
