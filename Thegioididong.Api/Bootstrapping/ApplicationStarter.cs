using Thegioididong.Api.Configurations;
using Thegioididong.Api.Middlewares;

namespace Thegioididong.Api.Bootstrapping
{
    public static class ApplicationStarter
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Api
            services.AddControllers();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            //Documentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Common
            services.AddAutoMapperConfiguration();
            services.AddDependencyInjectionConfiguration();

            //Data
            services.AddEntityFrameworkCoreConfiguration(configuration);

            return services;
        }

        public static WebApplication UseApplicationConfigurations(this WebApplication app)
        {
            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }

        public static ConfigureHostBuilder ConfigureHosts(this ConfigureHostBuilder hosts)
        {
            return hosts;
        }

        public static WebApplicationBuilder ConfigureWebAppBuilders(this WebApplicationBuilder builders)
        {
            builders.AddSerilogConfiguration();

            return builders;
        }
    }
}
