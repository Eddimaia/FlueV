using FluentV.Core.Patterns;
using System;
using System.Linq.Expressions;

namespace FluentV.Core.Rules
{
    public partial class RuleBuilder<TEntity> : RuleBuilder
        where TEntity : class
    {
        public RuleBuilder() : base() { }

        public RuleBuilder<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            var property = GetProperty(propertyExpression);
            ApplyFocus(property.Name, typeof(TProperty));
            RuleForProperty();
            return this;
        }

        #region General Rules - Rules that are the same for all types os properties

        public RuleBuilder<TEntity> Required(string message = null)
        {
            var rule = new Rule
            {
                Message = message ?? $"'{_propertyName}' {DefaultMessage.Required}"
            };

            rule.AcceptedValues.Add("Required");

            _rules[_propertyName].Add(rule);

            return this;
        }
        #endregion
    }
}
