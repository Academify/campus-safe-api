using CampusSafe.Domain.Base.Models;
using CampusSafe.Domain.Interfaces.Repository;
using CampusSafe.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusSafe.Api.Controllers;

[Route("api")]
[ApiController]
public class AuthController(ITokenService tokenService, IAuthRepository authRepository) : ControllerBase
{
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly ITokenService _tokenService = tokenService;
    
    
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ObjectResult GetToken([FromForm]ClientCredentials request)
    {
        Console.WriteLine("Authenticating user");
        var authenticated = _authRepository.AuthenticateUser(request).Result;
        return authenticated ? Ok(_tokenService.GenerateToken()) : Unauthorized("Invalid credentials");
    }
}