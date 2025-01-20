using CampusSafe.Api.Models;
using CampusSafe.Domain.Entities;

namespace CampusSafe.Api.Mapping;

public class UserMapper
{
    public static UserApiModel MapToUserApiModel(User? user)
    {
        return new UserApiModel
        {
            Name = user!.Name,
            Email = user.Email
        };
    }
}