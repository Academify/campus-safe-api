namespace CampusSafe.Domain.Interfaces.Repository;

public interface IBaseSqlRepository
{
    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null);
}