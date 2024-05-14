using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class MediaFolderConfiguration : EntityAuditBaseConfiguration<MediaFolder, int>
    {
        public override void Configure(EntityTypeBuilder<MediaFolder> builder)
        {
            base.Configure(builder);

            builder.Property(mf => mf.Name).HasMaxLength(191);
            builder.Property(mf => mf.Color).HasMaxLength(191);
            builder.Property(mf => mf.Slug).HasMaxLength(191);
            builder.Property(mf => mf.ParentId).IsRequired(false);
        }
    }
}