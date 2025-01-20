namespace CampusSafe.Infrastructure.Configuration;

using MySqlConnector;
using CampusSafe.Domain.Base.Adapters;
using Microsoft.Extensions.Configuration;

public class RelationalDatabaseConnection(IConfiguration configuration) : IDatabaseAdapter<MySqlConnection>
{
    public MySqlConnection GetConnection()
    {
        var connectionString = configuration.GetConnectionString("RelationalDatabase");
        var connection = new MySqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}