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
            #endregion
        }
    }
}
