using FluentV.Core.Enums;
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

            var rule = new Rule(message ?? GetDefaultMessage(_propertyName, DefaultMessage.WhiteSpace), EValidation.NotWhiteSpace);

            rule.AcceptedValues.Add("Values that are not white spaces");

            _rules[_propertyName].Rules.Add(rule);

            return this;
        }

        public RuleBuilder<TEntity> NotEmpty(string message = null)
        {
            if (_property != typeof(string) )
            {
                throw new InvalidOperationException($"The rule '{nameof(NotEmpty)}' can only be applied to properties of type string.");
            }

            var rule = new Rule(message ?? GetDefaultMessage(_propertyName, DefaultMessage.NotEmpty), EValidation.NotEmpty);

            rule.AcceptedValues.Add("Values that are not ''");

            _rules[_propertyName].Rules.Add(rule);

            return this;
        }
    }
}
