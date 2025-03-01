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
    public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany<EnterpriseAccount>()
                .WithOne()
                .HasForeignKey(e => e.Owner)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<User>()
                .WithOne()
                .HasForeignKey(u => u.WorkPlace)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
