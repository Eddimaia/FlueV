using FluentV.Core.Contract;
using FluentV.Core.Tests.Samples.Entities;

namespace FluentV.Core.Tests.Samples.Contracts;
public class SampleContract : Contract<SampleEntity>
{
    public SampleContract()
    {
        ApplyRulesFor(x => x.Required)
            .Required();

        ApplyRulesFor(x => x.WhiteSpaceString)
            .NotWhiteSpace();

        ApplyRulesFor(x => x.EmptyString)
            .NotEmpty();

        ApplyRulesFor(x => x.MoreThanOneRule)
            .NotWhiteSpace()
            .Required();
    }
}
