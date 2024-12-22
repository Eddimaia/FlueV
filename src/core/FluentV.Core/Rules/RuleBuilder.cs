using FluentV.Core.Enums;
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

        private string GetDefaultMessage(string propertyName, string defaultMesage)
        {
            return $"'{propertyName}' {defaultMesage}";
        }

        #region General Rules - Rules that are the same for all types os properties

        public RuleBuilder<TEntity> Required(string message = null)
        {
            var rule = new Rule(message ?? GetDefaultMessage(_propertyName, DefaultMessage.Required), EValidation.Required);

            rule.AcceptedValues.Add("Required");

            _rules[_propertyName].Rules.Add(rule);

            return this;
        }
        #endregion
    }
}
