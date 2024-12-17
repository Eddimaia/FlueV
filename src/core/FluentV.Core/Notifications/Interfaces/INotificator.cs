using System.Collections.Generic;

namespace FluentV.Core.Notifications.Interfaces
{
    public interface INotificator<TNotification> where TNotification : DefaultNotification
    {
        void AddNotification(TNotification notification);
        void AddNotifications(IEnumerable<TNotification> notifications);
    }
}
