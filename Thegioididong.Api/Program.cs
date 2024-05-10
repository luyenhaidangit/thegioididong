using Serilog;
using Thegioididong.Api.Bootstrapping;

var builder = WebApplication.CreateBuilder(args).ConfigureWebAppBuilders();

try
{
    //Configurations
    builder.Host.ConfigureHosts();

    builder.Services.ConfigureServices(builder.Configuration);

    //Build
    var app = builder.Build();

    Log.Information($"Start {builder.Environment.ApplicationName}");

    app.UseApplicationConfigurations();

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal)) throw;

    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information($"Shutdown {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}