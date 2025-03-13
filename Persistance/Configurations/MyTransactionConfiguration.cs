using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MyTransactionConfiguration : IEntityTypeConfiguration<MyTransaction>
    {
        public void Configure(EntityTypeBuilder<MyTransaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Sum)
                   .HasColumnType("decimal(18,2)");

            builder.Property(t => t.FromId)
                   .IsRequired(); 

            builder.Property(t => t.ToId)
                   .IsRequired(); 

            builder.Property(t => t.Date)
                   .IsRequired(); 
        }
    }
}
