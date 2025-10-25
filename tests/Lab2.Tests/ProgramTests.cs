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
        var message = new Message("Test1", "This is a test 1.", ImportanceLevel.Medium());

        var user = new User();
        var userAddressee = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee];

        var topic = new Topic("TopicTest1", addresses);
        topic.SendMessage(message);

        Assert.IsType<IsReadResult.NotRead>(user.IsRead(message));
    }

    [Fact]
    public void TryMarkAsRead_Scenario2_ReturnSuccess()
    {
        var message = new Message("Test2", "This is a test 2.", ImportanceLevel.Medium());

        var user = new User();
        var userAddressee = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee];

        var topic = new Topic("TopicTest2", addresses);
        topic.SendMessage(message);

        TryMarkAsReadResult result = user.TryMarkAsRead(message);
        Assert.IsType<IsReadResult.Read>(user.IsRead(message));
        Assert.IsType<TryMarkAsReadResult.Success>(result);
    }

    [Fact]
    public void TryMarkAsRead_Scenario3_ReturnAlreadyWasRead()
    {
        var message = new Message("Test3", "This is a test 3.", ImportanceLevel.Medium());

        var user = new User();
        var userAddressee = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee];

        var topic = new Topic("TopicTest3", addresses);
        topic.SendMessage(message);

        user.TryMarkAsRead(message);
        TryMarkAsReadResult result = user.TryMarkAsRead(message);
        Assert.IsType<TryMarkAsReadResult.AlreadyWasRead>(result);
    }

    [Fact]
    public void Receive_Scenario4_NotWasInReceive()
    {
        var message = new Message("Test4", "This is a test 4.", ImportanceLevel.Low());

        IAddressee mockAddressee = Substitute.For<IAddressee>();
        var filterAddressee = new FilterAddresseeProxy(mockAddressee, ImportanceLevel.Medium());
        List<IAddressee> addresses = [filterAddressee];

        var topic = new Topic("TopicTest4", addresses);
        topic.SendMessage(message);

        mockAddressee.DidNotReceive().Receive(Arg.Any<Message>());
    }

    [Fact]
    public void ReceiveAndLog_Scenario5_WasInReceiveAndLog()
    {
        var message = new Message("Test5", "This is a test 5.", ImportanceLevel.Medium());

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
        var message = new Message("Test6", "This is a test 6.", ImportanceLevel.Medium());

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
        var message = new Message("Test7", "This is a test 7.", ImportanceLevel.Medium());

        IAddressee mockUserAddressee1 = Substitute.For<IAddressee>();
        IAddressee mockUserAddressee2 = Substitute.For<IAddressee>();
        var filterUserAddressee2 = new FilterAddresseeProxy(mockUserAddressee2, ImportanceLevel.High());
        List<IAddressee> addresses = [mockUserAddressee1, filterUserAddressee2];

        var topic = new Topic("TopicTest7", addresses);
        topic.SendMessage(message);

        mockUserAddressee1.Received(1).Receive(Arg.Any<Message>());
        mockUserAddressee2.DidNotReceive().Receive(Arg.Any<Message>());
    }

    [Fact]
    public void CountMessages_Scenario8_EqualsOne()
    {
        var message = new Message("Test8", "This is a test 8.", ImportanceLevel.Medium());

        var user = new User();
        var userAddressee1 = new UserAddressee(user);
        var userAddressee2 = new UserAddressee(user);
        List<IAddressee> addresses = [userAddressee1, userAddressee2];

        var topic = new Topic("TopicTest8", addresses);
        topic.SendMessage(message);

        Assert.Equal(1, user.CountMessages);
    }
}