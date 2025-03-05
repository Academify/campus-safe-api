using CampusSafe.Api.Mapping;
using CampusSafe.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusSafe.Api.Controllers;

[Route("api")]
[ApiController]
[Authorize]
public class UserController(IUserRepository userRepository, ILogger<UserController> logger) : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet("users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ObjectResult> GetUser(Guid id)
    {
        _logger.LogInformation($"Getting user with id: {id}");
        var result = UserMapper.MapToUserApiModel(await _userRepository.GetUserById(id));
        return Ok(result);
    }
}