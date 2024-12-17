using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentV.Core.Validations
{
    public abstract partial class ValidationRules<TEntity> where TEntity : class
    {
        public Dictionary<string, List<string>> Rules => _rules;
        public Dictionary<string, List<string>> _rules;
        protected ValidationRules()
        {
            _rules = new Dictionary<string, List<string>>();
        }

        public ValidationRules<TEntity> RequireRulesFor<TResult>(Expression<Func<TEntity, TResult>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);

            if (_rules.ContainsKey(propertyName))
            {
                return this;
            }

            _rules.Add(propertyName, new List<string>());

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

            throw new ArgumentException("A expressão deve referenciar uma propriedade válida.", nameof(propertyExpression));
        }
    }
}
