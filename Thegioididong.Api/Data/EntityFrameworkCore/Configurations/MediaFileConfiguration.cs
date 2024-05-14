using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class MediaFileConfiguration : EntityAuditBaseConfiguration<MediaFile, int>
    {
        public override void Configure(EntityTypeBuilder<MediaFile> builder)
        {
            base.Configure(builder);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(191);
            builder.Property(m => m.AltText).HasMaxLength(191);
            builder.Property(m => m.MimeType).IsRequired().HasMaxLength(120);
            builder.Property(m => m.URL).IsRequired().HasMaxLength(191);
        }
    }
}