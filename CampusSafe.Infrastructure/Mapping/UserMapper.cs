using CampusSafe.Domain.Entities;
using CampusSafe.Infrastructure.Model;

namespace CampusSafe.Infrastructure.Mapping;

public static class UserMapper
{
    public static User? MapToUser(UserDto? userDto)
    {
        return (userDto == null) ? null : new User(userDto.Id, userDto.Name, userDto.Email);
    }
}