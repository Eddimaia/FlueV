using FluentV.Core.Patterns;
using FluentV.Core.Validations.Rules;
using System;

namespace FluentV.Core.Validations
{
    public partial class ValidationRules<TEntity>
    {
        public ValidationRules<TEntity> NotWhiteSpace(string message = null)
        {
            if ( _memberInFocusType != typeof(string) )
            {
                throw new InvalidOperationException($"The rule '{nameof(NotWhiteSpace)}' can only be applied to properties of type string.");
            }

            var rule = new Rule
            {
                Message = message ?? $"'{_memberInFocus}' {DefaultMessage.WhiteSpace}"
            };

            rule.AcceptedValues.Add("Values that are not white spaces");

            _rules[_memberInFocus].Add(rule);

            return this;
        }

        public ValidationRules<TEntity> NotEmpty(string message = null)
        {
            if ( _memberInFocusType != typeof(string) )
            {
                throw new InvalidOperationException($"The rule '{nameof(NotEmpty)}' can only be applied to properties of type string.");
            }

            var rule = new Rule
            {
                Message = message ?? $"'{_memberInFocus}' {DefaultMessage.NotEmpty}"
            };

            rule.AcceptedValues.Add("Values that are not ''");

            _rules[_memberInFocus].Add(rule);

            return this;
        }
    }
}
