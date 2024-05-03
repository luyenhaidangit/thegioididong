using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.EntityFrameworkCore.Configurations;

namespace Thegioididong.Api.Data.EntityFrameworkCore
{
    public static class ApplicationConfiguration
    {
        public static void ApplyApplicationConfigurations(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
