using System.Runtime.Serialization;

namespace CampusSafe.Domain.Base.Exceptions;

[Serializable]
public class NoResultsException : Exception
{
    public List<Notification> Notifications { get; private set; } = new();

    public NoResultsException(string message)
    {
        Notifications.Add(message);
    }
    protected NoResultsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}