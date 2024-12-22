using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentV.Core.Rules
{
    public abstract class RuleBuilder
    {
        public Dictionary<string, RuleInfo> Rules => _rules;
        protected readonly Dictionary<string, RuleInfo> _rules;

        protected string _propertyName;
        protected Type _property;

        protected RuleBuilder()
        {
            _rules = new Dictionary<string, RuleInfo>();
        }

        protected virtual void ApplyFocus(string name, Type type)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            _propertyName = name;
            _property = type ?? throw new ArgumentNullException(nameof(type));
        }

        public void RuleForProperty()
        {
            if (string.IsNullOrEmpty(_propertyName))
            {
                throw new ArgumentNullException(nameof(_propertyName));
            }

            if (!_rules.ContainsKey(_propertyName))
            {
                _rules.Add(_propertyName, new RuleInfo(_property));
            }
        }

        protected MemberInfo GetProperty<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member;
            }

            if (propertyExpression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
            {
                return operand.Member;
            }

            throw new ArgumentException("The expression must reference a valid property.", nameof(propertyExpression));
        }
    }
}
