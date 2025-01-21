using CampusSafe.Domain.Base.Adapters;
using CampusSafe.Domain.Base.Exceptions;
using CampusSafe.Domain.Entities;
using CampusSafe.Domain.Interfaces;
using CampusSafe.Infrastructure.Configuration;
using CampusSafe.Infrastructure.Mapping;
using CampusSafe.Infrastructure.Model;
using Dapper;
using MySqlConnector;

namespace CampusSafe.Infrastructure.Repository;

public class AlertsSqlRepository : IAlertRepository
{
    private readonly IDatabaseAdapter<MySqlConnection> _databaseAdapter;
    
    public AlertsSqlRepository(IDatabaseAdapter<MySqlConnection> databaseAdapter)
    {
        _databaseAdapter = databaseAdapter;
    }
    
    public async Task<Alert> GetAlertById(Guid id)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", id);
        var alert = await QueryAsync<AlertDto>(Constants.AlertsSqlQueries.GET_ALERT_BY_ID, parameters);
        return AlertMapper.MapToAlert(alert.FirstOrDefault()) ?? throw new NoResultsException("No alert found with the given id.");;
    }

    public async Task<bool> ThrowNewAlert(Alert alert)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", alert.Id);
        parameters.Add("@message", alert.Message);
        parameters.Add("@startedDateTime", alert.StartedDateTime);
        parameters.Add("@latitude", alert.Latitude);
        parameters.Add("@longitude", alert.Longitude);
        parameters.Add("@status", alert.Status.ToString());
        
        var result = await QueryAsync<AlertDto>(Constants.AlertsSqlQueries.INSERT_ALERT, parameters);
        
        return result.Any();
    }

    public async Task<bool> UpdateAlert(Alert alert)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", alert.Id);
        parameters.Add("@message", alert.Message);
        parameters.Add("@startedDateTime", alert.StartedDateTime);
        parameters.Add("@latitude", alert.Latitude);
        parameters.Add("@longitude", alert.Longitude);
        parameters.Add("@status", alert.Status.ToString());
        
        var result = await QueryAsync<AlertDto>(Constants.AlertsSqlQueries.UPDATE_ALERT, parameters);
        return result.Any();
    }

    public async Task<IEnumerable<Alert>> GetAlerts()
    {
        var alerts = await QueryAsync<AlertDto>(Constants.AlertsSqlQueries.GET_ALERTS);
        return alerts.Select(AlertMapper.MapToAlert);
    }

    public Task<bool> DeleteAlert(Guid id)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", id);
        return QueryAsync<AlertDto>(Constants.AlertsSqlQueries.DELETE_ALERT, parameters).ContinueWith(task => task.Result.Any());
    }

    public Task<IEnumerable<Alert>> GetAlertsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alert>> GetAlertsByLocation(string latitude, string longitude)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alert>> GetAlertsByDateAndLocation(DateTime date, string latitude, string longitude)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alert>> GetAlertsByDateRange(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alert>> GetAlertsByLocationRange(string latitude, string longitude, double range)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alert>> GetAlertsByDateAndLocationRange(DateTime date, string latitude, string longitude, double range)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Alert>> GetAlertsByDateRangeAndLocationRange(DateTime startDate, DateTime endDate, string latitude, string longitude,
        double range)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
    {
        using var connectionClient = _databaseAdapter.GetConnection();
        return await connectionClient.QueryAsync<T>(new CommandDefinition(sql, parameters));
    }
}