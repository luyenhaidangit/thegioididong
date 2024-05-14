using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class MediaSettingConfiguration : EntityAuditBaseConfiguration<MediaSetting, int>
    {
        public override void Configure(EntityTypeBuilder<MediaSetting> builder)
        {
            base.Configure(builder);
        }
    }
}