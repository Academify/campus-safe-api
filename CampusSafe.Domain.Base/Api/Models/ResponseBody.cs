namespace CampusSafe.Domain.Base.Api.Models;

public class ResponseBody<T>(T data)
{
    public T Data { get; private set; } = data;

    public static implicit operator ResponseBody<T>(T data)
    {
        return new ResponseBody<T>(data);
    }
}