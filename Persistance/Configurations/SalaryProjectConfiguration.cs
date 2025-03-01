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
    public class SalaryProjectConfiguration : IEntityTypeConfiguration<SalaryProject>
    {
        public void Configure(EntityTypeBuilder<SalaryProject> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");
        }
    }
}
