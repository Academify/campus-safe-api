using CampusSafe.Api.Mapping;
using CampusSafe.Api.Models;
using CampusSafe.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusSafe.Api.Controllers;

[Route("api")]
[ApiController]
public class UserController(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    [HttpGet("users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public UserApiModel GetUser(Guid id)
    {
        return UserMapper.MapToUserApiModel(_userRepository.GetUserById(id));
    }
}