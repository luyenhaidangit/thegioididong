using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore.Configurations.Common;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class TagTranslationConfiguration : TranslatableConfiguration<TagTranslation>
    {
        public override void Configure(EntityTypeBuilder<TagTranslation> builder)
        {
            base.Configure(builder);

            builder.ToTable("tags_translations");

            #region Primary Key
            builder.HasKey(tt => new { tt.LangCode, tt.TagId });
            #endregion

            #region Properties
            builder.Property(tt => tt.TagId)
                   .IsRequired()
                   .HasColumnName("tags_id");

            builder.Property(tt => tt.Name)
                   .HasMaxLength(255)
                   .HasColumnName("name");

            builder.Property(tt => tt.Description)
                   .HasMaxLength(400)
                   .HasColumnName("description");
            #endregion
        }
    }
}