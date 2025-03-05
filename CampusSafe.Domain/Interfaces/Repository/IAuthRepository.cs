using CampusSafe.Domain.Base.Models;

namespace CampusSafe.Domain.Interfaces.Repository;

public interface IAuthRepository
{
    public Task<bool> AuthenticateUser(ClientCredentials clientCredentials);
}