using FluentV.Core.Patterns;
using FluentV.Core.Tests.Samples.Contracts;
using FluentV.Core.Tests.Samples.Entities;

namespace FluentV.Core.Tests.Validadtions;
public class StringRulesTests
{
    public SampleContract _contract = new SampleContract();

    [Fact]
    public void Not_White_Space()
    {
        Assert.Contains(DefaultMessage.WhiteSpace, _contract.Rules[nameof(SampleEntity.WhiteSpaceString)].First().Message);
        Assert.Equal("Values that are not white spaces", _contract.Rules[nameof(SampleEntity.WhiteSpaceString)].First().AcceptedValues.First());
    }
}
