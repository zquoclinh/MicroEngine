using MicroEngine.Data.Entities;
using MicroEngine.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroEngine.Data.Builders
{
    public class CodelistBuilder : IEntityTypeConfiguration<Codelist>
    {
        public void Configure(EntityTypeBuilder<Codelist> builder)
        {
            builder.Property(s => s.CodeGroup).IsRequired().AsString(10);
            builder.Property(s => s.CodeName).IsRequired().AsString(10);
            builder.Property(s => s.CodeId).IsRequired().AsString(10);
            builder.Property(s => s.Caption).IsRequired().AsString(100);
        }
    }
}
