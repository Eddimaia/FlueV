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
    public void Should_Result_Validation_Rules_Instance()
    {
        var contract = new Contract<SampleEntity>();

        RuleBuilder<SampleEntity>  builder = contract.ApplyRulesFor(x => x.NoRule);

        Assert.NotNull(contract);
        Assert.IsAssignableFrom<RuleBuilder<SampleEntity>>(builder);
        Assert.IsType<Contract<SampleEntity>>(contract);
        Assert.True(contract.Rules.ContainsKey(nameof(SampleEntity.NoRule)));
        Assert.True(contract.Rules[nameof(SampleEntity.NoRule)].Count == 0);
    }

    [Fact]
    public void Required_Is_Required()
    {
        Assert.Contains(DefaultMessage.Required, _contract.Rules[nameof(SampleEntity.Required)].First().Message);
        Assert.Equal("Required", _contract.Rules[nameof(SampleEntity.Required)].First().AcceptedValues.First());
    }
}
