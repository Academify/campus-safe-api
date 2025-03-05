using CampusSafe.Domain.Base.Api.Middlewares;
using CampusSafe.Domain.Base.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CampusSafe.DependencyInjection;

public static class ConfigureServices
{
    public static IApplicationBuilder AddCampusSafeSwaggerSettings(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
    public static IApplicationBuilder AddCampusSafeHttpSettings(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandler>();
        app.UseHttpLogging();
        app.UseStaticFiles();

        return app;
    }
    public static ILoggingBuilder AddLogginServices(this ILoggingBuilder loggin)
    {
        loggin.ClearProviders();
        loggin.AddConsole();

        return loggin;
    }
    public static IServiceCollection AddCampusSafeApiBaseServices(this IServiceCollection services)
    {
        services.AddHttpLogging(o => { });
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }
}