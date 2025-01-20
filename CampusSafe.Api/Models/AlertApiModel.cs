namespace CampusSafe.Api.Models;

public class AlertApiModel
{
    public string Message { get; set; } = string.Empty;
    public DateTime StartedDateTime { get; set; }
    public string Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}