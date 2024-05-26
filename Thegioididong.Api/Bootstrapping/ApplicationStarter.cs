using Thegioididong.Api.Configurations;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Middlewares;

namespace Thegioididong.Api.Bootstrapping
{
    public static class ApplicationStarter
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Api
            services.AddControllers(options =>
            {
            });
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            //Documentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Common
            services.AddLogging();
            services.AddAutoMapperConfiguration();
            services.AddDependencyInjectionConfiguration();
            services.AddFluentValidationConfiguration();

            //Data
            services.AddEntityFrameworkCoreConfiguration(configuration);

            return services;
        }

        public static WebApplication UseApplicationConfigurations(this WebApplication app)
        {
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<BadRequestHandlingMiddleware>();
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
