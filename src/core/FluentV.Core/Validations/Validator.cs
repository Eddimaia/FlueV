using FluentV.Core.Enums;
using FluentV.Core.Notifications;
using FluentV.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentV.Core.Validations
{
    public class Validator<TNotification, TEntity>
        where TNotification : DefaultNotification
        where TEntity : class
    {
        private readonly Notificator<TNotification> _notificator;
        private readonly RuleBuilder<TEntity> _validationRules;
        private readonly Dictionary<string, RuleInfo> _rules;
        public Notificator<TNotification> Notificator => _notificator;

        public Validator(Notificator<TNotification> notificator, RuleBuilder<TEntity> validationRules)
        {
            _notificator = notificator;
            _validationRules = validationRules;
            _rules = validationRules.Rules;
        }

        public Validator<TNotification, TEntity> ValidateProperty<TResult>(Expression<Func<TEntity, TResult>> propertyExpression, object value)
        {
            var propertyName = GetPropertyName(propertyExpression);
            return ValidateProperty(propertyName, value);
        }

        public Validator<TNotification, TEntity> ValidateProperty(string propertyName, object value)
        {
            if (!_rules.TryGetValue(propertyName, out var propertyInfo))
            {
                throw new ArgumentException($"There are no rules applied to property '{propertyName}'");
            }

            GeneralValidations(propertyName, propertyInfo.Rules, value);

            if (propertyInfo.PropertyType == typeof(string))
            {
                StringValidations(propertyName, propertyInfo.Rules, value);
            }
            return this;
        }

        protected virtual void GeneralValidations(string propertyName, List<Rule> propertyRules, object value)
        {
            var rule = propertyRules.FirstOrDefault(x => x.Validation == EValidation.Required);
            if (rule != null)
            {
                if (Validations.IsNull(value))
                {
                    AddNotification(typeof(TEntity), propertyName, rule.Message);
                }

            }
        }

        protected virtual void StringValidations(string propertyName, List<Rule> propertyRules, object value)
        {
            var rule = propertyRules.FirstOrDefault(x => x.Validation == EValidation.NotEmpty);
            if (rule != null)
            {
                if (Validations.IsEmptyString(value.ToString()))
                {
                    AddNotification(typeof(TEntity), propertyName, rule.Message);
                }
            }

            rule = propertyRules.FirstOrDefault(x => x.Validation == EValidation.NotWhiteSpace);
            if (rule != null)
            {
                if (Validations.IsWhiteSpaceString(value.ToString()))
                {
                    AddNotification(typeof(TEntity), propertyName, rule.Message);
                }
            }
        }

        protected virtual void AddNotification(Type assembly, string propertyName, string message)
        {
            _notificator.
                AddNotification(assembly, propertyName, message);
        }

        private string GetPropertyName<TResult>(Expression<Func<TEntity, TResult>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (propertyExpression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
            {
                return operand.Member.Name;
            }

            throw new ArgumentException("The expression must reference a valid property.", nameof(propertyExpression));
        }
    }
}
