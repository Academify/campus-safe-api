using CampusSafe.Domain.Base.Exceptions;
using CampusSafe.Infrastructure.Model;
using CampusSafe.Domain.Base.Adapters;
using CampusSafe.Domain.Base.Exceptions;
using CampusSafe.Domain.Entities;
using CampusSafe.Domain.Interfaces;
using CampusSafe.Infrastructure.Mapping;
using Dapper;
using MySqlConnector;

namespace CampusSafe.Infrastructure.Repository;

public class SqlRepository(IDatabaseAdapter<MySqlConnection> databaseAdapter) : IUserRepository
{
    private const string GET_USER_BY_ID = "SELECT * FROM Users WHERE Id = @Id";
    
    public User? GetUserById(Guid id)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", id);
        var user = QueryAsync<UserDto>(GET_USER_BY_ID, parameters).Result.FirstOrDefault();
        if (user == null) throw new NoResultsException("No user found with the given id.");
        return UserMapper.MapToUser(user);
    }
    
    private async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
    {
        using var connectionClient = databaseAdapter.GetConnection();
        return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
    }
}