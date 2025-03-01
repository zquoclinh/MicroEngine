using MicroEngine.Data.Entities;
using MicroEngine.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroEngine.Data.Builders
{
    public class CustomerBuilder : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(s => s.CustomerID).IsRequired().AsString(10);
            builder.HasKey(s => s.CustomerID);
            builder.HasIndex(s => s.CustomerID);
            builder.Property(s => s.CustomerName).IsRequired().AsString(50);
        }
    }
}
