using CampusSafe.Domain.Base.Models;
using CampusSafe.Domain.Interfaces.Repository;
using Dapper;

namespace CampusSafe.Infrastructure.Repository;

public class AuthRepository(BaseSqlRepository baseSqlRepository) : IAuthRepository
{
    private readonly BaseSqlRepository _baseSqlRepository = baseSqlRepository;
    
    public async Task<bool> AuthenticateUser(ClientCredentials clientCredentials)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@clientId", clientCredentials.ClientId);
        parameters.Add("@clientSecret", clientCredentials.ClientSecret);
        var exists = await _baseSqlRepository.QueryAsync<bool>(Constants.AuthSqlQueries.GET_CLIENT_CREDENTIALS, parameters);
        return exists.FirstOrDefault();
    }
}