using CampusSafe.Domain.Entities;

namespace CampusSafe.Domain.Interfaces;

public interface IUserRepository
{
    public Task<User> GetUserById(Guid id);
}