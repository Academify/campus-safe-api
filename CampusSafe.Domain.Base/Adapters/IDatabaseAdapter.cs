namespace CampusSafe.Domain.Base.Adapters;

public interface IDatabaseAdapter<T>
{
    public T GetConnection();
}