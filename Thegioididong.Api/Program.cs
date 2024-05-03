using Serilog;
using Thegioididong.Api.Extensions;
using Thegioididong.Api.Services.Interfaces;
using Thegioididong.Api.Services;
using Thegioididong.Api.Repositories.Interfaces;
using Thegioididong.Api.Repositories;
using Thegioididong.Api.Contracts.Data.Repositories;
using Thegioididong.Api.Infrastructures.Data.Repositories;
using Thegioididong.Api.Contracts.Data.UnitOfWork;
using Thegioididong.Api.Infrastructures.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

Log.Information($"Start {builder.Environment.ApplicationName} up");

try
{
    builder.Host.AddAppConfigurations(builder.Configuration,builder.Environment);
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddScoped(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
    builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();

    var app = builder.Build();
    app.UseInfrastructure();
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