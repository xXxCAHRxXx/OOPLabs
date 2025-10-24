using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Topics;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ProgramTests
{
    [Fact]
    public void IsReaded_Scenario1_False()
    {
        var message = new Message("Test1", "This is a test 1.", new ImportanceLevel.Medium());

        var user = new User();
        var userAddressee = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee];

        var topic = new Topic("TopicTest1", addresses);
        topic.SendMessage(message);

        Assert.False(user.ReceivedMessages[0].IsReaded);
    }

    [Fact]
    public void TryMarkAsRead_Scenario2_ReturnSuccess()
    {
        var message = new Message("Test2", "This is a test 2.", new ImportanceLevel.Medium());

        var user = new User();
        var userAddressee = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee];

        var topic = new Topic("TopicTest2", addresses);
        topic.SendMessage(message);

        UserResultType result = user.TryMarkAsRead(0);
        Assert.True(user.ReceivedMessages[0].IsReaded);
        Assert.IsType<UserResultType.Success>(result);
    }

    [Fact]
    public void TryMarkAsRead_Scenario3_ReturnAlreadyWasRead()
    {
        var message = new Message("Test3", "This is a test 3.", new ImportanceLevel.Medium());

        var user = new User();
        var userAddressee = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee];

        var topic = new Topic("TopicTest3", addresses);
        topic.SendMessage(message);

        user.TryMarkAsRead(0);
        UserResultType result = user.TryMarkAsRead(0);
        Assert.IsType<UserResultType.AlreadyWasRead>(result);
    }

    [Fact]
    public void Receive_Scenario4_NotWasInReceive()
    {
        var message = new Message("Test4", "This is a test 4.", new ImportanceLevel.Low());

        IAddressee mockAddressee = Substitute.For<IAddressee>();
        var filterAddressee = new FilterAddresseeProxy(mockAddressee, new ImportanceLevel.Medium());
        List<IAddressee> addresses = [filterAddressee];

        var topic = new Topic("TopicTest4", addresses);
        topic.SendMessage(message);

        mockAddressee.DidNotReceive().Receive(Arg.Any<Message>());
    }

    [Fact]
    public void ReceiveAndLog_Scenario5_WasInReceiveAndLog()
    {
        var message = new Message("Test5", "This is a test 5.", new ImportanceLevel.Medium());

        ILogger mockLogger = Substitute.For<ILogger>();
        IAddressee mockAddressee = Substitute.For<IAddressee>();
        var loggingAddressee = new LoggingAddresseeDecorator(mockAddressee, mockLogger);
        List<IAddressee> addresses = [loggingAddressee];

        var topic = new Topic("TopicTest5", addresses);
        topic.SendMessage(message);

        mockAddressee.Received(1).Receive(Arg.Any<Message>());
        mockLogger.Received(1).Log(Arg.Any<string>());
    }

    [Fact]
    public void WriteHeadBody_Scenario6_WasInWriteHeadBody()
    {
        var message = new Message("Test6", "This is a test 6.", new ImportanceLevel.Medium());

        IFormatter mockFormatter = Substitute.For<IFormatter>();
        var formattingArchiver = new FormattingArchiver(mockFormatter);
        var formattingArchiverAddressee = new ArchiverAddressee(formattingArchiver);
        List<IAddressee> addresses = [formattingArchiverAddressee];

        var topic = new Topic("TopicTest6", addresses);
        topic.SendMessage(message);

        mockFormatter.Received(1).WriteHead(Arg.Any<string>());
        mockFormatter.Received(1).WriteBody(Arg.Any<string>());
    }

    [Fact]
    public void ReceivedMessages_Scenario7_ReceivedMessagesLengthOne()
    {
        var message = new Message("Test7", "This is a test 7.", new ImportanceLevel.Medium());

        var user = new User();
        var userAddressee1 = new UserAddressee(user);
        var userAddressee2 = new UserAddressee(user);
        var filterUserAddressee2 = new FilterAddresseeProxy(userAddressee2, new ImportanceLevel.High());
        List<IAddressee> addresses = [userAddressee1, filterUserAddressee2];

        var topic = new Topic("TopicTest7", addresses);
        topic.SendMessage(message);

        Assert.Single(user.ReceivedMessages);
    }
}