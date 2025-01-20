using CampusSafe.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CampusSafe.Api.Controllers;

[Route("api")]
[ApiController]
public class AlertController
{
    [HttpGet("alerts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public string GetAlerts()
    {
        return "Alerts";
    }
    
    [HttpPost("alerts")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public string PostAlert(AlertApiModel alertApiModel)
    {
        return $"Alert: {alertApiModel.Message} created.";
    }
}