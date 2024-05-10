using System.Reflection;

namespace Thegioididong.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Services
            var assembly = Assembly.GetExecutingAssembly();

            var serviceProjectNamespace = $"{Assembly.GetCallingAssembly().GetName().Name}.Services";

            var serviceTypes = assembly.GetTypes()
                .Where(type => type.Namespace == serviceProjectNamespace && !type.IsAbstract && !type.IsInterface);

            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType);
            }

            return services;
        }
    }
}
