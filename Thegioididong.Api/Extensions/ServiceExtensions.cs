using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Thegioididong.Api.Attributes;
using Thegioididong.Api.Contracts.Data.Repositories;
using Thegioididong.Api.Contracts.Data.UnitOfWork;
using Thegioididong.Api.Data.EntityFrameworkCore;
using Thegioididong.Api.Infrastructures.Data.Repositories;
using Thegioididong.Api.Infrastructures.Data.UnitOfWork;
using Thegioididong.Api.Models.Configurations;

namespace Thegioididong.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.ConfigureApplicationDbContext(configuration);
            services.RegisterServices(configuration);

            return services;
        }

        private static IServiceCollection ConfigureApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            if (databaseSettings == null || string.IsNullOrEmpty(databaseSettings.ConnectionString))
                throw new ArgumentNullException("Connection string is not configured.");

            var builder = new MySqlConnectionStringBuilder(databaseSettings.ConnectionString);
            services.AddDbContext<ApplicationDbContext>(m => m.UseMySql(builder.ConnectionString,
                ServerVersion.AutoDetect(builder.ConnectionString), e =>
                {
                    e.MigrationsAssembly("Thegioididong.Api");
                    e.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                }));

            return services;
        }

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Define types that need matching
            Type scopedRegistration = typeof(ScopedRegistrationAttribute);
            Type singletonRegistration = typeof(SingletonRegistrationAttribute);
            Type transientRegistration = typeof(TransientRegistrationAttribute);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsDefined(scopedRegistration, true) || p.IsDefined(transientRegistration, true) || p.IsDefined(singletonRegistration, true) && !p.IsInterface).Select(s => new
                {
                    Service = s.GetInterface($"I{s.Name}"),
                    Implementation = s
                }).Where(x => x.Service != null);

            foreach (var type in types)
            {
                if (type.Implementation.IsDefined(scopedRegistration, false))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }

                if (type.Implementation.IsDefined(transientRegistration, false))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }

                if (type.Implementation.IsDefined(singletonRegistration, false))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
            }

            //Register custom service
            services.AddScoped(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
