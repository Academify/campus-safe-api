using CampusSafe.Api.Models;
using CampusSafe.Domain.Entities;
using CampusSafe.Domain.Enums;

namespace CampusSafe.Api.Mapping;

public static class AlertMapper
{
    public static AlertApiModel MapToAlertApiModel(Alert? alert)
    {
        return new AlertApiModel
        {
            StartedDateTime = alert!.StartedDateTime,
            Message = alert.Message,
            Latitude = alert.Latitude,
            Longitude = alert.Longitude,
            Status = alert.Status.ToString()
        };
    }
    
    public static Alert MapToAlert(AlertApiModel alert)
    {
        return new Alert
        (
            alert.Message,
            alert.StartedDateTime,
            alert.Latitude,
            alert.Longitude,
            Enum.Parse<AlertStatusEnum>(alert.Status)
        )
        {
            StartedDateTime = default,
            Status = AlertStatusEnum.Active
        };
    }
}