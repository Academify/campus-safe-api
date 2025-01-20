using CampusSafe.Domain.Entities;

namespace CampusSafe.Domain.Interfaces;

public interface IAlertRepository
{
    public Task<Alert> GetAlertById(Guid id);
    public Task ThrowNewAlert(Alert alert);
    public Task UpdateAlert(Alert alert);
    public Task<IEnumerable<Alert>> GetAlerts();
    public Task<IEnumerable<Alert>> GetAlertsByDate(DateTime date);
    public Task<IEnumerable<Alert>> GetAlertsByLocation(string latitude, string longitude);
    public Task<IEnumerable<Alert>> GetAlertsByDateAndLocation(DateTime date, string latitude, string longitude);
    public Task<IEnumerable<Alert>> GetAlertsByDateRange(DateTime startDate, DateTime endDate);
    public Task<IEnumerable<Alert>> GetAlertsByLocationRange(string latitude, string longitude, double range);
    public Task<IEnumerable<Alert>> GetAlertsByDateAndLocationRange(DateTime date, string latitude, string longitude, double range);
    public Task<IEnumerable<Alert>> GetAlertsByDateRangeAndLocationRange(DateTime startDate, DateTime endDate, string latitude, string longitude, double range);
}