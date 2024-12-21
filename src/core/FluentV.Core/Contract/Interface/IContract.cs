using FluentV.Core.Rules;
using System.Linq.Expressions;
using System;

namespace FluentV.Core.Contract.Interface
{
    public interface IContract<TEntity> where TEntity : class
    {
        RuleBuilder<TEntity> ApplyRulesFor<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression);
    }
}
