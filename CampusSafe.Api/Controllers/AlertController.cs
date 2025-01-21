using CampusSafe.Api.Models;
using CampusSafe.Domain.Base.Exceptions;
using CampusSafe.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AlertMapper = CampusSafe.Api.Mapping.AlertMapper;

namespace CampusSafe.Api.Controllers;

[Route("api")]
[ApiController]
public class AlertController(IAlertRepository alertRepository, ILogger<AlertController> logger) : ControllerBase
{
    private readonly ILogger<AlertController> _logger = logger;
    private readonly IAlertRepository _alertRepository = alertRepository;
    
    [HttpGet("alerts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ObjectResult> GetAlerts()
    {
        _logger.LogInformation("Getting all alerts");
        var result = (await _alertRepository.GetAlerts()).Select(AlertMapper.MapToAlertApiModel);
        return Ok(result);
    }
    
    [HttpGet("alerts/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ObjectResult> GetAlertById(Guid id)
    {
        _logger.LogInformation($"Getting alert with id: {id}");
        var result = AlertMapper.MapToAlertApiModel(await _alertRepository.GetAlertById(id));
        return Ok(result);
    }
    
    [HttpPost("alerts")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ObjectResult> ThrowNewAlert([FromBody] AlertApiModel alert)
    {
        _logger.LogInformation("Throwing new alert");
        var result = await _alertRepository.ThrowNewAlert(AlertMapper.MapToAlert(alert));
        return result ? Created("alert", alert) : throw new InfrastructureFailedException("Failed to throw new alert.");
    }
    
    [HttpPut("alerts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ObjectResult> UpdateAlert([FromBody] AlertApiModel alert)
    {
        _logger.LogInformation($"Updating alert with id: {alert}");
        var result = await _alertRepository.UpdateAlert(AlertMapper.MapToAlert(alert));
        return result ? Ok(result) : throw new InfrastructureFailedException("Failed to update alert.");
    }
    
    [HttpDelete("alerts/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ObjectResult> DeleteAlert(Guid id)
    {
        _logger.LogInformation($"Deleting alert with id: {id}");
        var result = await _alertRepository.DeleteAlert(id);
        return result ? Ok(result) : throw new InfrastructureFailedException("Failed to delete alert.");
    }
    
}