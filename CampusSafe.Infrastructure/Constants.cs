namespace CampusSafe.Infrastructure;

public static class Constants
{
    public static class UsersSqlQueries
    {
        public static readonly string GET_USER_BY_ID = "SELECT * FROM Users WHERE Id = @Id";
    }
    public static class AlertsSqlQueries
    {
        public static readonly string GET_ALERTS = "SELECT * FROM Alerts";
        public static readonly string GET_ALERT_BY_ID = "SELECT * FROM Alerts WHERE Id = @Id";
        public static readonly string INSERT_ALERT = "INSERT INTO Alerts (Id, Message, StartedDateTime, Latitude, Longitude, Status) VALUES (@id, @message, @startedDateTime, @latitude, @longitude, @status)";
        public static readonly string UPDATE_ALERT = "UPDATE Alerts SET Message = @message, StartedDateTime = @startedDateTime, Latitude = @latitude, Longitude = @longitude, Status = @status WHERE Id = @id";
        public static readonly string DELETE_ALERT = "DELETE FROM Alerts WHERE Id = @id";
    }
    
    public static class AuthSqlQueries
    {
        public static readonly string GET_CLIENT_CREDENTIALS = "SELECT CASE WHEN EXISTS(SELECT 1 FROM ClientCredentials WHERE ClientId = @clientId AND ClientSecret = @clientSecret) THEN TRUE ELSE FALSE END";
    }
}