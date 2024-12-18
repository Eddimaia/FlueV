using FluentV.Core.Notifications;

namespace FluentV.Core.Tests.Validadtions;

[Collection("Validator")]
public class NotificatorTests
{
    private readonly Notificator<DefaultNotification> _validator = new();

    [Fact]
    public void Should_Create_One_Notification()
    {
        _validator.AddNotification(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", -1, ["1", "2", "3"]);

        var notification = _validator.Notifications.First();

        Assert.False(_validator.IsValid);
        Assert.Single(_validator.Notifications);
        Assert.Equal(-1, notification.Value);
        Assert.Equal("Not valid", notification.Message);
        Assert.Equal(typeof(MoqClass), notification.Assembly);
        Assert.Equal(nameof(MoqClass.Id), notification.PropertyName);
        Assert.Equal(["1", "2", "3"], notification.AcceptedValues);
    }

    [Fact]
    public void Should_Create_One_Notification_Input_Notification()
    {
        var expectedNotification = new DefaultNotification(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", -1, ["1", "2", "3"]);

        _validator.AddNotification(expectedNotification);

        var notification = _validator.Notifications.First();

        Assert.False(_validator.IsValid);
        Assert.Single(_validator.Notifications);
        Assert.Equal(-1, notification.Value);
        Assert.Equal("Not valid", notification.Message);
        Assert.Equal(typeof(MoqClass), notification.Assembly);
        Assert.Equal(nameof(MoqClass.Id), notification.PropertyName);
        Assert.Equal(["1", "2", "3"], notification.AcceptedValues);
    }

    [Fact]
    public void Should_Create_One_Notification_Input_CustomNotification()
    {
        var date = DateTime.Now;
        var expectedNotification = new CustomNotification(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", -1, ["1", "2", "3"], date);

        _validator.AddNotification(expectedNotification);

        var notification = (CustomNotification)_validator.Notifications.First();

        Assert.False(_validator.IsValid);
        Assert.Single(_validator.Notifications);
        Assert.Equal(-1, notification.Value);
        Assert.Equal("Not valid", notification.Message);
        Assert.Equal(typeof(MoqClass), notification.Assembly);
        Assert.Equal(nameof(MoqClass.Id), notification.PropertyName);
        Assert.Equal(["1", "2", "3"], notification.AcceptedValues);
        Assert.Equal(date, notification.Date);
    }

    [Theory]
    [MemberData(nameof(TestList))]
    public void Should_Create_Two_Notifications(List<DefaultNotification> notifications)
    {
        _validator.AddNotifications(notifications);

        Assert.Equal(2, _validator.Notifications.Count);
    }

    #region Asserts
    private class MoqClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    private class CustomNotification(Type assembly, string propertyName, string message, object value, List<string> acceptedValues, DateTime date)
        : DefaultNotification(assembly, propertyName, message, value, acceptedValues)
    {
        public DateTime Date { get; private set; } = date;
    }

    public static List<object[]> TestList
        =>
        [
           new object[]
           {
               new List<DefaultNotification>()
               {
                   new(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", -1, ["1", "2", "3"]),
                   new CustomNotification(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", false, ["1", "2", "3"], DateTime.Now)
               }
           }
        ];
    #endregion
}
