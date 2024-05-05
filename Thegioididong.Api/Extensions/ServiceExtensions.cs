using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Reflection;
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

            services.AddAutoMapperProvider();

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
            //Register service with interface
            //References: https://stackoverflow.com/questions/72116669/how-to-register-services-with-dependency-container-services-by-reflection-in-c-s
            //Type scopedRegistration = typeof(ScopedRegistrationAttribute);
            //Type singletonRegistration = typeof(SingletonRegistrationAttribute);
            //Type transientRegistration = typeof(TransientRegistrationAttribute);

            //var types = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => p.IsDefined(scopedRegistration, true) || p.IsDefined(transientRegistration, true) || p.IsDefined(singletonRegistration, true) && !p.IsInterface).Select(s => new
            //    {
            //        Service = s.GetInterface($"I{s.Name}"),
            //        Implementation = s
            //    }).Where(x => x.Service != null);

            //foreach (var type in types)
            //{
            //    if (type.Implementation.IsDefined(scopedRegistration, false))
            //    {
            //        services.AddScoped(type.Service, type.Implementation);
            //    }

            //    if (type.Implementation.IsDefined(transientRegistration, false))
            //    {
            //        services.AddTransient(type.Service, type.Implementation);
            //    }

            //    if (type.Implementation.IsDefined(singletonRegistration, false))
            //    {
            //        services.AddSingleton(type.Service, type.Implementation);
            //    }
            //}

            //Register DI when use Repository Partern
            //services.AddScoped(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
            //services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            //Register DI for service by namespace
            var assembly = Assembly.GetExecutingAssembly();

            var serviceProjectNamespace = $"{Assembly.GetCallingAssembly().GetName().Name}.Services";

            var serviceTypes = assembly.GetTypes()
                .Where(type => type.Namespace == serviceProjectNamespace && !type.IsAbstract && !type.IsInterface);

            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType);
            }
        }

        public static IServiceCollection AddAutoMapperProvider(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));

            return services;
        }
    }
}
