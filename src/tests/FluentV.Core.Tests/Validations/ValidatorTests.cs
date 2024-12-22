using FluentV.Core.Notifications;
using FluentV.Core.Tests.Samples.Contracts;
using FluentV.Core.Tests.Samples.Entities;
using FluentV.Core.Validations;

namespace FluentV.Core.Tests.Validations;
public class ValidatorTests
{
    private SampleEntity _sampleEntity => new SampleEntity();
    private SampleContract _contract = new SampleContract();
    private Notificator<DefaultNotification> _notificator = new Notificator<DefaultNotification>();

    [Fact]
    public void Should_Validate_Property_For_Empty_Strings()
    {
        var validator = new Validator<DefaultNotification, SampleEntity>(_notificator, _contract.RuleBuilder);
        validator.ValidateProperty(x => x.EmptyString, _sampleEntity.EmptyString);

        Assert.False(validator.Notificator.IsValid);
        Assert.Single(validator.Notificator.Notifications);
    }
}


