using C4WX1.API.Features.Activity.Repository;
using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.CarePlanSubGoal.Repository;
using C4WX1.API.Features.Chat.Repository;
using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Security;
using C4WX1.API.Features.SysConfig.Repository;
using C4WX1.Database.Models;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;
using Serilog.Events;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

    builder.Services.AddTransient<IChatRepository, ChatRepository>();
    builder.Services.AddTransient<ISecurityService, SecurityService>();
    builder.Services.AddTransient<IPasswordGenerator, PasswordGenerator>();
    builder.Services.AddTransient<ISysConfigRepository, SysConfigRepository>();
    builder.Services.AddTransient<IActivityRepository, ActivityRepository>();
    builder.Services.AddTransient<IChatRepository, ChatRepository>();
    builder.Services.AddTransient<IBranchRepository, BranchRepository>();
    builder.Services.AddTransient<ICarePlanSubGoalRepository, CarePlanSubGoalRepository>();

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
            c.Serializer.Options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            c.Serializer.Options.PropertyNamingPolicy = null;
            c.Binding.UsePropertyNamingPolicy = true;
        })
        .UseSwaggerGen();

    app.UseMetricServer();
    app.UseHttpMetrics(options =>
    {
        options.AddCustomLabel("route", context =>
            context.Request.Path.HasValue ? context.Request.Path.Value : "unknown");
        options.ReduceStatusCodeCardinality();
    });

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