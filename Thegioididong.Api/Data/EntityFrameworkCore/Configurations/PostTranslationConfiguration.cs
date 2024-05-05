using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore.Configurations.Common;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class PostTranslationConfiguration : TranslatableConfiguration<PostTranslation>
    {
        public override void Configure(EntityTypeBuilder<PostTranslation> builder)
        {
            base.Configure(builder);

            builder.ToTable("posts_translations");

            #region Primary Key
            builder.HasKey(pt => new { pt.LangCode, pt.PostId });
            #endregion

            #region Properties
            builder.Property(pt => pt.PostId)
                   .IsRequired()
                   .HasColumnName("posts_id");

            builder.Property(pt => pt.Content)
                   .HasColumnType("longtext")
                   .HasColumnName("content");
            #endregion
        }
    }
}