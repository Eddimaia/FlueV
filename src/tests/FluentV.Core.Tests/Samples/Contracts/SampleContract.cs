using FluentV.Core.Tests.Samples.Entities;
using FluentV.Core.Validations;

namespace FluentV.Core.Tests.Samples.Contracts;
public class SampleContract : ValidationRules<SampleEntity>
{
    public SampleContract()
    {
        RequireRulesFor(x => x.Required)
            .Required();

        RequireRulesFor(x => x.WhiteSpaceString)
            .NotWhiteSpace();

        RequireRulesFor(x => x.EmptyString)
            .NotEmpty();
    }
}
