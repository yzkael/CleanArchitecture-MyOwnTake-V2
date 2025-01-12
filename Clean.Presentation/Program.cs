using Clean.Infrastructure.Configurations;
using Clean.Infrastructure.Data;
using Clean.Infrastructure.Models;
using Clean.Presentation.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

try
{
    Log.Information("App starting...");
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    SerilogConfig.ConfigureLogger();
    builder.Host.UseSerilog(); // SO it doesnt default to the other logger but uses serilog
    builder.Services.AddControllers();
    builder.Services.ConfigureDbContext(builder.Configuration);
    builder.Services.ConfigureEntity();
    builder.Services.ConfigureAuthentication(builder.Configuration);
    builder.Services.ConfigurateAuthorization();
    builder.Services.AddDependencyInjection();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
catch (System.Exception ex)
{
    Log.Fatal(ex, "Host Terminated Unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
