using FluentValidation;
using System.Reflection;

namespace Thegioididong.Api.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
