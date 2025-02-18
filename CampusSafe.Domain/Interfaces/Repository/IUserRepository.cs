using CampusSafe.Domain.Entities;

namespace CampusSafe.Domain.Interfaces.Repository;

public interface IUserRepository
{
    public Task<User> GetUserById(Guid id);
}