using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;
using Thegioididong.Api.Data.EntityFrameworkCore.Configurations.Common;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class CategoryTranslationConfiguration : TranslatableConfiguration<CategoryTranslation>
    {
        public override void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            base.Configure(builder);

            builder.ToTable("categories_translations");

            #region Primary Key
            builder.HasKey(ct => new { ct.LangCode, ct.CategoryId });
            #endregion

            #region Indexes
            #endregion

            #region Properties
            builder.Property(ct => ct.CategoryId)
                   .IsRequired()
                   .HasColumnName("categories_id");
            #endregion
        }
    }
}