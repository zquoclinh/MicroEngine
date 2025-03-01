using MicroEngine.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroEngine.Framework.Entity.Builder
{
    public class SettingBuilder : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(x => x.Name).IsRequired().AsString(100);
            builder.HasKey(x => x.Name);
            builder.Property(x => x.Value).IsRequired().AsString(500);
        }
    }
}
