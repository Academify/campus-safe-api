using CampusSafe.Domain.Base.Models;
using CampusSafe.Domain.Enums;

namespace CampusSafe.Domain.Entities;

public class Alert : Validatable
{
    public required DateTime StartedDateTime { get; set; }
    public string Message { get; set; }
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }
    public required AlertStatusEnum Status { get; set; }

    public Alert(string message, DateTime startedDateTime, string latitude, string longitude, AlertStatusEnum status)
    {
        if (startedDateTime > DateTime.Now) AddNotification("startedDateTime can't be in the future");
        
        Validate();
        
        Status = status;
        Message = message;
        StartedDateTime = startedDateTime;
        Latitude = latitude;
        Longitude = longitude;
    }
}