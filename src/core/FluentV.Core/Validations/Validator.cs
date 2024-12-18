using FluentV.Core.Enums;
using FluentV.Core.Notifications;
using FluentV.Core.Notifications.Interfaces;
using FluentV.Core.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentV.Core.Validations
{
    public class Validator<TNotification, TEntity>
        where TNotification : DefaultNotification
        where TEntity : class
    {
        private readonly Notificator<TNotification> _notificator;
        private readonly ValidationRules<TEntity> _validationRules;
        public Notificator<TNotification> Notificator => _notificator;

        public Validator(Notificator<TNotification> notificator, ValidationRules<TEntity> validationRules)
        {
            _notificator = notificator;
            _validationRules = validationRules;
        }

        public Validator<TNotification, TEntity> ValidateString<TResult>(Expression<Func<TEntity, TResult>> propertyExpression, string value)
        {
            var propertyName = GetPropertyName(propertyExpression);

            var rules = _validationRules.Rules[propertyName];
            var rule = rules.FirstOrDefault(x => x.ValidationType == EValidationType.Required);
            if ( rule != null  )
            {
                if ( Validations.IsNull(value) )
                {
                    _notificator
                        .AddNotification(typeof(TEntity), propertyName, rule.Message, value, rule.AcceptedValues.Select(x => "'" + x + "'").ToList());
                }

            }
            return this;
        }

        private string GetPropertyName<TResult>(Expression<Func<TEntity, TResult>> propertyExpression)
        {
            if ( propertyExpression.Body is MemberExpression memberExpression )
            {
                return memberExpression.Member.Name;
            }

            if ( propertyExpression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand )
            {
                return operand.Member.Name;
            }

            throw new ArgumentException("The expression must reference a valid property.", nameof(propertyExpression));
        }
    }
}
