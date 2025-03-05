using System.Text;
using CampusSafe.Domain.Base.Adapters;
using CampusSafe.Domain.Interfaces.Repository;
using CampusSafe.Domain.Interfaces.Services;
using CampusSafe.Infrastructure.Configuration;
using CampusSafe.Infrastructure.Repository;
using CampusSafe.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace CampusSafe.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddRelationalDatabaseServices(this IServiceCollection services)
    {
        services.AddScoped<RelationalDatabaseConnection>();
        services.AddTransient<BaseSqlRepository>();
        services.AddScoped<IUserRepository, UsersSqlSqlRepository>();
        services.AddScoped<IAlertRepository, AlertsSqlRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IDatabaseAdapter<MySqlConnection>, RelationalDatabaseConnection>();
        return services;
    }
    
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<TokenService>();
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
        
        services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
    
    public static IServiceCollection AddSwaggerGenConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT no formato: Bearer {seu_token_aqui}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new string[] { }
                }
            });
        });
        return services;
    }
}