using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public IReadOnlyList<ReceivedMessage> ReceivedMessages => _receivedMessages;

    private readonly List<ReceivedMessage> _receivedMessages = [];

    public void Receive(Message message)
    {
        _receivedMessages.Add(new ReceivedMessage(message));
    }

    public UserResultType TryMarkAsRead(int i)
    {
        if (i < 0 || i >= _receivedMessages.Count)
            return new UserResultType.OutOfRangeMessages();

        if (!_receivedMessages[i].TryMarkAsRead())
            return new UserResultType.AlreadyWasRead();

        return new UserResultType.Success();
    }
}