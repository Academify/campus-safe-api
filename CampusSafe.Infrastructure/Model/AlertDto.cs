using CampusSafe.Domain.Enums;

namespace CampusSafe.Infrastructure.Model;

public class AlertDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartedDateTime { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;
    public AlertStatusEnum Status { get; set; }
}