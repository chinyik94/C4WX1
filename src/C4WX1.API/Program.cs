using C4WX1.API.Features.Chat.Repository;
using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Security;
using C4WX1.Database.Models;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/C4WX1-api-.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true,
        retainedFileTimeLimit: TimeSpan.FromDays(30),
        restrictedToMinimumLevel: LogEventLevel.Information)
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    builder.Services.AddFastEndpoints()
        .SwaggerDocument();

    builder.Services.AddSerilog();

    builder.Services.AddDbContext<THCC_C4WDEVContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddTransient<IChatRepository, ChatRepository>();
    builder.Services.AddTransient<ISecurityService, SecurityService>();
    builder.Services.AddTransient<IPasswordGenerator, PasswordGenerator>();

    var app = builder.Build();

    app
        .UseDefaultExceptionHandler()
        .UseFastEndpoints(c =>
        {
            c.Endpoints.RoutePrefix = "api";
            c.Endpoints.Configurator = ep =>
            {
                ep.AllowAnonymous();
                ep.Description(b =>
                    b.ProducesProblemFE<InternalErrorResponse>(500));
            };
        })
        .UseSwaggerGen();

    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}