using DevIO.Business.Notifications;
using System.Collections.Immutable;

namespace DevIO.Business.Interfaces;

public interface INotifier
{
    bool HasNotifications { get; }

    ImmutableList<Notification> GetNotifications();
    void AddNotification(Notification notification);
}
