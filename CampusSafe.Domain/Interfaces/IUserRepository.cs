using CampusSafe.Domain.Entities;

namespace CampusSafe.Domain.Interfaces;

public interface IUserRepository
{
    public User? GetUserById(Guid id);
}