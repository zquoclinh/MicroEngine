using MicroEngine.Data.Entities;
using MicroEngine.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroEngine.Data.Builders
{
    public class EmailTemplateBuilder : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.Property(s => s.TemplateId).IsRequired().AsString(50);
            builder.HasKey(s => s.TemplateId);
            builder.Property(s => s.Status).IsRequired().AsString(10);
            builder.Property(s => s.Description).AsString(500).IsRequired(false);
            builder.Property(s => s.Subject).AsString(500).IsRequired();
            builder.Property(s => s.Body).IsRequired();
            builder.Property(s => s.Attachments).IsRequired(false);
        }
    }
}
