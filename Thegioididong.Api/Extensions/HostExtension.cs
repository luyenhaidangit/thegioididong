using Serilog;
using Thegioididong.Api.Configurations;

namespace Thegioididong.Api.Extensions
{
    public static class HostExtension
    {
        public static void AddAppConfigurations(this ConfigureHostBuilder host, ConfigurationManager configuration, IWebHostEnvironment environment)
        {
            configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            host.UseSerilog(SerilogConfiguration.Instance);
        }
    }
}
