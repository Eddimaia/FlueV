using FluentV.Core.Notifications;
using System.Collections.Generic;

namespace FluentV.Core.Validations.Interfaces
{
    public interface IValidator<TNotification> where TNotification : DefaultNotification
    {
        void AddNotification(TNotification notification);
        void AddNotifications(IEnumerable<TNotification> notifications);
    }
}
