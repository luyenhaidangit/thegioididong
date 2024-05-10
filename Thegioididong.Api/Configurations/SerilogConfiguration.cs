using Serilog;

namespace Thegioididong.Api.Configurations
{
    public static class SerilogConfiguration
    {
        public static WebApplicationBuilder AddSerilogConfiguration(this WebApplicationBuilder builders)
        {
            builders.Host.UseSerilog(Instance);

            return builders;
        }

        public static Action<HostBuilderContext, LoggerConfiguration> Instance =>
        (context, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .WriteTo.Debug()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
                .Enrich.FromLogContext();

            //var applicationName = context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-");
            //var environmentName = context.HostingEnvironment.EnvironmentName ?? "Development";
            //var elasticUri = context.Configuration.GetValue<string>("ElasticConfiguration:Uri");
            //var username = context.Configuration.GetValue<string>("ElasticConfiguration:Username");
            //var password = context.Configuration.GetValue<string>("ElasticConfiguration:Password");

            //.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
            //{
            //    IndexFormat = $"tedulogs-{applicationName}-{environmentName}-{DateTime.UtcNow:yyyy-MM}",
            //    AutoRegisterTemplate = true,
            //    NumberOfReplicas = 1,
            //    NumberOfShards = 2,
            //    ModifyConnectionSettings = x => x.BasicAuthentication(username, password)
            //})
            //.Enrich.FromLogContext()
            //.Enrich.WithMachineName()
            //.Enrich.WithProperty("Environment", environmentName)
            //.Enrich.WithProperty("Application", applicationName)
        };
    }
}
