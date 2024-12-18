using FluentV.Core.Patterns;
using FluentV.Core.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentV.Core.Validations
{
    public abstract partial class ValidationRules<TEntity> where TEntity : class
    {
        public Dictionary<string, List<Rule>> Rules => _rules;
        private Dictionary<string, List<Rule>> _rules;

        private string _memberInFocus;
        private Type _memberInFocusType;
        protected ValidationRules()
        {
            _rules = new Dictionary<string, List<Rule>>();
        }

        public ValidationRules<TEntity> RequireRulesFor<TResult>(Expression<Func<TEntity, TResult>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);

            if (!_rules.ContainsKey(propertyName))
            {
                _rules.Add(propertyName, new List<Rule>());
            }

            _memberInFocus = propertyName;
            _memberInFocusType = typeof(TResult);

            return this;
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

        #region General Rules - Rules that are the same for all types os properties

        public ValidationRules<TEntity> Required(string message = null)
        {
            var rule = new Rule
            {
                Message = message ?? $"'{_memberInFocus}' {DefaultMessage.Required}"
            };

            rule.AcceptedValues.Add("Required");

            _rules[_memberInFocus].Add(rule);

            return this;
        }
        #endregion
    }
}
