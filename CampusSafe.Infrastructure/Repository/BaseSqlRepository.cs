using CampusSafe.Domain.Base.Adapters;
using CampusSafe.Domain.Interfaces.Repository;
using Dapper;
using MySqlConnector;

namespace CampusSafe.Infrastructure.Repository;

public class BaseSqlRepository : IBaseSqlRepository
{
    private readonly IDatabaseAdapter<MySqlConnection> _databaseAdapter;
    
    public BaseSqlRepository(IDatabaseAdapter<MySqlConnection> databaseAdapter)
    {
        _databaseAdapter = databaseAdapter;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
    {
        using var connectionClient = _databaseAdapter.GetConnection();
        return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
    }
}