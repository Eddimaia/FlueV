using FluentV.Core.Patterns;
using FluentV.Core.Tests.Samples.Contracts;
using FluentV.Core.Tests.Samples.Entities;
using FluentV.Core.Validations;

namespace FluentV.Core.Tests.Rules;
public class ValidationRulesTests
{
    public SampleContract _contract = new SampleContract();
    [Fact]
    public void Should_Result_Validation_Rules_Instance()
    {
        ValidationRules<SampleEntity> contract = new SampleContract();

        contract = contract.RequireRulesFor(x => x.NoRule);

        Assert.NotNull(contract);
        Assert.IsAssignableFrom<ValidationRules<SampleEntity>>(contract);
        Assert.IsType<SampleContract>(contract);
        Assert.True(contract.Rules.ContainsKey(nameof(SampleEntity.NoRule)));
    }

    [Fact]
    public void Required_Is_Required()
    {
        Assert.Contains(DefaultMessage.Required, _contract.Rules[nameof(SampleEntity.Required)].First().Message);
        Assert.Equal("Required", _contract.Rules[nameof(SampleEntity.Required)].First().AcceptedValues.First());
    }
}
