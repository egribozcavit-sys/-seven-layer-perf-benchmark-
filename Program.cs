using Serilog;
using PayCore.API.Extensions;
using PayCore.Infrastructure.Configuration;
using PayCore.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateBootstrapLogger();

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

try
{
    Log.Information("Starting PayCore Enterprise");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add Application Layer
    builder.Services.AddApplicationLayer();

    // Add Infrastructure Layer
    builder.Services.AddInfrastructureLayer(builder.Configuration);

    // Add Persistence Layer
    builder.Services.AddPersistenceLayer(builder.Configuration);

    // Add Health Checks
    builder.Services.AddHealthChecks()
        .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .AddRedis(builder.Configuration.GetConnectionString("Redis"));

    var app = builder.Build();

    // Configure pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSerilogRequestLogging();

    app.MapControllers();
    app.MapHealthChecks("/health");

    // Apply migrations
    await app.ApplyMigrations();

    Log.Information("PayCore Enterprise started successfully");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
