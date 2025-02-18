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
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        services.AddSingleton<TokenService>();
        return services;
    }
    
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        //Tem erro aqui
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Minha API",
                Version = "v1"
            });

            // Definir esquema de segurança
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
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
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
        return services;
    }
}