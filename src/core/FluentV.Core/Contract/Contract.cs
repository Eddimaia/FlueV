using FluentV.Core.Contract.Interface;
using FluentV.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentV.Core.Contract
{
    public class Contract<TEntity> : IContract<TEntity> where TEntity : class
    {
        private readonly RuleBuilder<TEntity> _ruleBuilder;
        public Dictionary<string, List<Rule>> Rules => _ruleBuilder.Rules;
        public Contract()
        {
            _ruleBuilder = new RuleBuilder<TEntity>();
        }
        public RuleBuilder<TEntity> ApplyRulesFor<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
        {
            _ruleBuilder
                .Property(propertyExpression);

            return _ruleBuilder;
        }
    }
}
