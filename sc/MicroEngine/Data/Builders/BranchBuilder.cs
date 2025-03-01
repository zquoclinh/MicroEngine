using MicroEngine.Data.Entities;
using MicroEngine.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroEngine.Data.Builders
{
    public class BranchBuilder : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(s => s.BranchCode).IsRequired().AsString(10);
            builder.Property(s => s.BranchName).IsRequired().AsString(50);
        }
    }
}
