using CampusSafe.Domain.Base.Adapters;
using Dapper;
using MySqlConnector;

namespace CampusSafe.Infrastructure.Repository;

public class BaseSqlRepository
{
    private readonly IDatabaseAdapter<MySqlConnection> _databaseAdapter;
    
    public BaseSqlRepository(IDatabaseAdapter<MySqlConnection> databaseAdapter)
    {
        _databaseAdapter = databaseAdapter;
    }

    protected BaseSqlRepository() { }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
    {
        using var connectionClient = _databaseAdapter.GetConnection();
        return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
    }
}