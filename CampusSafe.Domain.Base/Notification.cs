namespace CampusSafe.Domain.Base;

public class Notification(string message)
{
    public string Message { get; } = message;

    public override string ToString()
    {
        return Message;
    }

    public static implicit operator Notification(string message)
    {
        return new Notification(message);
    }

    public static implicit operator string(Notification notification)
    {
        return notification.Message;
    }
}