using CampusSafe.Domain.Base.Exceptions;

namespace CampusSafe.Domain.Base.Models;

public class Validatable : Entity
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool Validated => !Notifications.Any();
    public void AddNotification(string message) => Notifications.Add(message);
    public void AddNotification(Notification notification) => Notifications.Add(notification);
    public void AddNotifications(IEnumerable<Notification> notifications) => Notifications.AddRange(notifications);
    protected void ClearNotifications() => Notifications.Clear();
    public bool Validate()
    {
        if (Notifications.Any())
            throw new InvalidDomainStateException(Notifications);
        return true;
    }
}