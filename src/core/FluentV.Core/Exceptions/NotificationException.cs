using FluentV.Core.Notifications;
using FluentV.Core.Validations;
using FluentV.Core.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentV.Core.Exceptions
{
    /// <summary>
    /// Custom exception that encapsulates notifacations.
    /// </summary>
    /// <typeparam name="TNotification">Type of notification, must inherit <see cref="DefaultNotification"/>.</typeparam>
    public class NotificationException<TNotification> : Exception, IValidator<TNotification>
        where TNotification : DefaultNotification
    {
        private readonly Validator<TNotification> _validator;
        public new string Message { get; private set; } = "Some assembly has validation errors";
        public IReadOnlyCollection<TNotification> Notifications => _validator.Notifications;

        private NotificationException() : base()
        {
            _validator = new Validator<TNotification>();
        }

        /// <summary>
        /// Initializes a new instance of the class <see cref="NotificationException{TNotification}"/> com notificações associadas.
        /// </summary>
        /// <param name="notifications">List of notifications associated with the exception.</param>
        public NotificationException(IEnumerable<TNotification> notifications) : this()
        {

            if (notifications != null)
            {
                _validator.AddNotifications(notifications);
            }

            Message = string.Join($"{Environment.NewLine}", _validator.Notifications.Select(x => x.ToString()));
        }

        /// <summary>
        /// Initializes a new instance of the class <see cref="NotificationException{TNotification}"/> com notificações associadas.
        /// </summary>
        /// <param name="notifications">Params of notifications associated with the exception.</param>
        public NotificationException(params TNotification[] notifications)
            : this((IEnumerable<TNotification>)notifications)
        {
        }

        public void AddNotification(TNotification notification)
        {
            _validator.AddNotification(notification);
        }

        public void AddNotifications(IEnumerable<TNotification> notifications)
        {
            _validator.AddNotifications(notifications);
        }
    }
}
