using FluentV.Core.Tests.Samples.Contracts;
using FluentV.Core.Tests.Samples.Entities;
using FluentV.Core.Validations;

namespace FluentV.Core.Tests.Validadtions;
public class ValidationRulesTests
{
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
}
