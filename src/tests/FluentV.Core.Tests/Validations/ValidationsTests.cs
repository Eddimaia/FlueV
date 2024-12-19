namespace FluentV.Core.Tests.Validations;
public class ValidationsTests
{
    [Fact]
    public void Should_Validate_If_Value_Is_Null()
    {
        var validValue = "valid";
        int? invalidValue = null;

        var valid = Core.Validations.Validations.IsNull(validValue);
        var invalid = Core.Validations.Validations.IsNull(invalidValue);

        Assert.False(valid);
        Assert.True(invalid);
    }

    [Fact]
    public void Should_Validate_If_Value_Is_Empty_String()
    {
        var validValue = "valid";
        var invalidValue = string.Empty;

        var valid = Core.Validations.Validations.IsEmptyString(validValue);
        var invalid = Core.Validations.Validations.IsEmptyString(invalidValue);

        Assert.False(valid);
        Assert.True(invalid);
    }

    [Fact]
    public void Should_Validate_If_Value_Is_White_Space_String()
    {
        var validValue = "valid";
        var invalidValue = "     ";

        var valid = Core.Validations.Validations.IsWhiteSpaceString(validValue);
        var invalid = Core.Validations.Validations.IsWhiteSpaceString(invalidValue);

        Assert.False(valid);
        Assert.True(invalid);
    }
}
