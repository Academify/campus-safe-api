using CampusSafe.Domain.Base.Adapters;
using CampusSafe.Domain.Interfaces;
using CampusSafe.Infrastructure.Configuration;
using CampusSafe.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace CampusSafe.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddRelationalDatabaseServices(this IServiceCollection services)
    {
        services.AddScoped<RelationalDatabaseConnection>();
        services.AddScoped<BaseSqlRepository>();
        services.AddScoped<IUserRepository, UsersSqlSqlRepository>();
        services.AddScoped<IAlertRepository, AlertsSqlRepository>();
        services.AddScoped<IDatabaseAdapter<MySqlConnection>, RelationalDatabaseConnection>();
        return services;
    }
}