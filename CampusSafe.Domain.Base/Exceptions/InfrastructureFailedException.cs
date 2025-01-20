using System.Runtime.Serialization;

namespace CampusSafe.Domain.Base.Exceptions;

[Serializable]
public class InfrastructureFailedException : Exception
{
    public List<Notification> Notifications { get; private set; } = new();

    public InfrastructureFailedException(string message)
    {
        Notifications.Add(message);
    }

    public InfrastructureFailedException(List<Notification> notifications)
    {
        Notifications = notifications;
    }

    protected InfrastructureFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}