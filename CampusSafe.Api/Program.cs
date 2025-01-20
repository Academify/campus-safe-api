using CampusSafe.DependencyInjection;

namespace CampusSafe.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.AddLogginServices();
        builder.Services.AddCampusSafeApiBaseServices();
        builder.Services.AddRelationalDatabaseServices();
        
        var app = builder.Build();
        
        app.AddCampusSafeSwaggerSettings();
        app.AddCampusSafeHttpSettings();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}