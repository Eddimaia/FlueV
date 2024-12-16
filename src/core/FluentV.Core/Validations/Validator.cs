﻿using FluentV.Core.Notifications;
using FluentV.Core.Validations.Interfaces;
using System;
using System.Collections.Generic;

namespace FluentV.Core.Validations
{
    public class Validator<TNotification> : IValidator<TNotification> 
        where TNotification : DefaultNotification
    {
        private readonly List<TNotification> _notifications;
        public IReadOnlyCollection<TNotification> Notifications => _notifications;
        public bool IsValid => !(_notifications.Count > 0);

        public Validator() 
            => _notifications = new List<TNotification>();

        private TNotification CreateInstance(Type assembly, string propertyName, string message, object value, List<string> acceptedValues) 
            => Activator.CreateInstance(typeof(TNotification), assembly, propertyName, message, value, acceptedValues) as TNotification;

        public void AddNotification(TNotification notification) 
            => _notifications.Add(notification);

        public void AddNotifications(IEnumerable<TNotification> notifications) 
            => _notifications.AddRange(notifications);

        public void AddNotification(Type assembly, string propertyName, string message, object value, List<string> acceptedValues)
        {
            var notification = CreateInstance(assembly, propertyName, message, value, acceptedValues);
            _notifications.Add(notification);
        }
    }
}
