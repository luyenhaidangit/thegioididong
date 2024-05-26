using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Data.EntityFrameworkCore;

namespace Thegioididong.Api.Configurations
{
    public static class EntityFrameworkCoreConfiguration
    {
        public static IServiceCollection AddEntityFrameworkCoreConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
