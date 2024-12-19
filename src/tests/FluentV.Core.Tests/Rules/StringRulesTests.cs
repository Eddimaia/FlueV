using FluentV.Core.Patterns;
using FluentV.Core.Tests.Samples.Contracts;
using FluentV.Core.Tests.Samples.Entities;
using FluentV.Core.Validations.Rules;

namespace FluentV.Core.Tests.Rules;
public class StringRulesTests
{
    public SampleContract _contract = new SampleContract();

    [Fact]
    public void Not_White_Space()
    {
        Assert.Contains(DefaultMessage.WhiteSpace, _contract.Rules[nameof(SampleEntity.WhiteSpaceString)].First().Message);
        Assert.Equal("Values that are not white spaces", _contract.Rules[nameof(SampleEntity.WhiteSpaceString)].First().AcceptedValues.First());
    }

    [Fact]
    public void Not_Empty_String()
    {
        Assert.Contains(DefaultMessage.NotEmpty, _contract.Rules[nameof(SampleEntity.EmptyString)].First().Message);
        Assert.Equal("Values that are not ''", _contract.Rules[nameof(SampleEntity.EmptyString)].First().AcceptedValues.First());
    }
}
