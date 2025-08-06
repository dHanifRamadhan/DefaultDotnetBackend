using Serilog;
using DefaultDotnetBackend.Configurations;
using DefaultDotnetBackend.Helpers;

var builder = WebApplication.CreateBuilder(args);

ConsoleHelper.ShowWelcomeMessage();

// TODO: Configure Logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/DailyLog.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

builder.Host.UseSerilog();

if (builder.Environment.IsProduction())
    await builder.Configuration.AddTestDatabaseConnection();

// TODO: Add Configuration
builder.Services.AddConfigureService(builder.Configuration);

var app = builder.Build();

app.AddConfigureApp();
app.Run();
