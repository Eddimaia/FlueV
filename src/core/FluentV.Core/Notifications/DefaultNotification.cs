using System;
using System.Collections.Generic;

namespace FluentV.Core.Notifications
{
    public class DefaultNotification
    {
        public DefaultNotification(Type assembly, string propertyName, string message, object value, List<string> acceptedValues)
        {
            Assembly = assembly;
            PropertyName = propertyName;
            Message = message;
            Value = value;
            AcceptedValues = acceptedValues;
        }

        public Type Assembly { get; private set; }
        public string PropertyName { get; private set; }
        public string Message { get; private set; }
        public object Value { get; private set; }
        public List<string> AcceptedValues { get; private set; }
    }
}
