using CampusSafe.DependencyInjection;
using CampusSafe.Infrastructure.Services;

namespace CampusSafe.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAuthenticationServices(builder.Configuration);
        builder.Services.AddAuthorization();
        
        builder.Logging.AddLogginServices();
        builder.Services.AddCampusSafeApiBaseServices();
        builder.Services.AddRelationalDatabaseServices();
        builder.Services.AddSwaggerGenConfig();
        
        var app = builder.Build();
        
        app.AddCampusSafeSwaggerSettings();
        app.AddCampusSafeHttpSettings();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}