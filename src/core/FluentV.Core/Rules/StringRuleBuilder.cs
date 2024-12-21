using FluentV.Core.Patterns;
using System;

namespace FluentV.Core.Rules
{
    public partial class RuleBuilder<TEntity>
    {
        public RuleBuilder<TEntity> NotWhiteSpace(string message = null)
        {
            if ( _property != typeof(string) )
            {
                throw new InvalidOperationException($"The rule '{nameof(NotWhiteSpace)}' can only be applied to properties of type string.");
            }

            var rule = new Rule
            {
                Message = message ?? $"'{_propertyName}' {DefaultMessage.WhiteSpace}"
            };

            rule.AcceptedValues.Add("Values that are not white spaces");

            _rules[_propertyName].Add(rule);

            return this;
        }

        public RuleBuilder<TEntity> NotEmpty(string message = null)
        {
            if (_property != typeof(string) )
            {
                throw new InvalidOperationException($"The rule '{nameof(NotEmpty)}' can only be applied to properties of type string.");
            }

            var rule = new Rule
            {
                Message = message ?? $"'{_propertyName}' {DefaultMessage.NotEmpty}"
            };

            rule.AcceptedValues.Add("Values that are not ''");

            _rules[_propertyName].Add(rule);

            return this;
        }
    }
}
