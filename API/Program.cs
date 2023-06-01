using API.Repositories;
using API.Services;
using NLog;
using NLog.Web;

// Init logger
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("starting application");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services
        .AddControllers()
        .AddNewtonsoftJson();

    // Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Repositories
    builder.Services.AddRepositories();

    // Services
    builder.Services.AddServices(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    
    app.UseCors(e => e
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(_ => true)
        .AllowCredentials());
    
    app.Run();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}