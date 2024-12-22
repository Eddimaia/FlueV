using FluentV.Core.Contract;
using FluentV.Core.Patterns;
using FluentV.Core.Rules;
using FluentV.Core.Tests.Samples.Contracts;
using FluentV.Core.Tests.Samples.Entities;

namespace FluentV.Core.Tests.Rules;
public class RuleBuilderTests
{
    public SampleContract _contract = new SampleContract();
    [Fact]
    public void Should_Result_Rule_Builder_Instance()
    {
        var contract = new Contract<SampleEntity>();

        RuleBuilder<SampleEntity>  builder = contract.ApplyRulesFor(x => x.NoRule);

        Assert.NotNull(contract);
        Assert.IsAssignableFrom<RuleBuilder<SampleEntity>>(builder);
        Assert.IsType<Contract<SampleEntity>>(contract);
        Assert.True(contract.Rules.ContainsKey(nameof(SampleEntity.NoRule)));
        Assert.True(contract.Rules[nameof(SampleEntity.NoRule)].Rules.Count == 0);
    }

    [Fact]
    public void Required_Is_Required()
    {
        Assert.Contains(DefaultMessage.Required, _contract.Rules[nameof(SampleEntity.Required)].Rules.First().Message);
        Assert.Equal("Required", _contract.Rules[nameof(SampleEntity.Required)].Rules.First().AcceptedValues.First());
    }

    [Fact]
    public void Should_Throw_Exception_For_Not_Valid_Type_Validation()
    {
        Assert.Throws<InvalidOperationException>(() => new FailContract());
    }

    [Fact]
    public void Should_Result_In_More_Than_One_Rule()
    {
        Assert.Equal(2, _contract.Rules[nameof(SampleEntity.MoreThanOneRule)].Rules.Count);
    }

    #region Asserts
    public class FailContract : Contract<SampleEntity>
    {
        public FailContract()
        {
            ApplyRulesFor(x => x.NoRule)
                .NotEmpty();
        }
    }
    #endregion
}
