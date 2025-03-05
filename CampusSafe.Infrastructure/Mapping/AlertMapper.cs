using CampusSafe.Domain.Entities;
using CampusSafe.Domain.Enums;
using CampusSafe.Infrastructure.Model;

namespace CampusSafe.Infrastructure.Mapping;

public class AlertMapper
{
    public static Alert MapToAlert(AlertDto? alertDto)
    {
        return (alertDto == null) ? null : new Alert(alertDto.Message, alertDto.StartedDateTime, alertDto.Latitude, alertDto.Longitude, AlertStatusEnum.Active)
        {
            StartedDateTime = default,
            Latitude = null,
            Longitude = null,
            Status = AlertStatusEnum.Active
        };
    }
}