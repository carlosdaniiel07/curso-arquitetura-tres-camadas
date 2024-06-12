using DevIO.Business.Interfaces;
using System.Collections.Immutable;

namespace DevIO.Business.Notifications;

public class Notifier : INotifier
{
    private readonly List<Notification> _notifications;

    public Notifier()
    {
        _notifications = [];
    }

    public bool HasNotifications =>
        _notifications.Any();

    public void AddNotification(Notification notification) =>
        _notifications.Add(notification);

    public ImmutableList<Notification> GetNotifications() =>
        _notifications.ToImmutableList();
}
