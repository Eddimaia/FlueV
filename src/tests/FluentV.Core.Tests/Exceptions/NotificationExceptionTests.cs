using FluentV.Core.Exceptions;
using FluentV.Core.Notifications;

namespace FluentV.Core.Tests.Exceptions;
public class NotificationExceptionTests
{
    [Fact]
    public void Should_Result_In_Exception_With_One_Notification()
    {
        var assertNotification = new DefaultNotification(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", -1, ["1", "2", "3"]);
        var exception = new NotificationException<DefaultNotification>(assertNotification);

        Assert.Single(exception.Notifications);
        Assert.Contains("'-1'", exception.Message);
        Assert.Contains("'Id'", exception.Message);
    }

    [Fact]
    public void Should_Not_Result_In_Exception()
    {
        var exception = new NotificationException<DefaultNotification>();

        Assert.Empty(exception.Notifications);
    }

    [Theory]
    [MemberData(nameof(TestList))]
    public void Should_Result_In_Execptions_With_Notifications_Post_Instance(List<DefaultNotification> notifications)
    {
        var exception = new NotificationException<DefaultNotification>();
        exception.AddNotifications(notifications);


        Assert.Equal(2, exception.Notifications.Count);
    }

    [Fact]
    public void Should_Result_In_Exception_With_One_Notification_Post_Instance()
    {
        var assertNotification = new DefaultNotification(typeof(MoqClass), nameof(MoqClass.Id), "Not valid", -1, ["1", "2", "3"]);
        var exception = new NotificationException<DefaultNotification>();
        exception.AddNotification(assertNotification);

        Assert.Single(exception.Notifications);
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
