using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.EntityFrameworkCore.Configurations;

namespace Thegioididong.Api.Data.EntityFrameworkCore
{
    public static class ApplicationConfiguration
    {
        public static void ApplyApplicationConfigurations(this ModelBuilder builder)
        {
            #region Blog
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CategoryTranslationConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PostTranslationConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());
            builder.ApplyConfiguration(new TagTranslationConfiguration());
            builder.ApplyConfiguration(new SlugConfiguration());
            #endregion

            #region Ecommerce
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            #endregion

            #region Media
            builder.ApplyConfiguration(new MediaFileConfiguration());
            builder.ApplyConfiguration(new MediaFolderConfiguration());
            builder.ApplyConfiguration(new MediaSettingConfiguration());
            #endregion
        }
    }
}
