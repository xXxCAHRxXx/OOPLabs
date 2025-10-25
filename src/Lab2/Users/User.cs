using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public int CountMessages => _receivedMessages.Count;

    private readonly List<ReceivedMessage> _receivedMessages = new();

    public void Receive(Message message)
    {
        if (!_receivedMessages.Any(existing
                => object.ReferenceEquals(existing.Message, message)))
        {
            _receivedMessages.Add(new ReceivedMessage(message));
        }
    }

    public IsReadResult IsRead(Message message)
    {
        ReceivedMessage? existing = _receivedMessages
            .FirstOrDefault(existing => object.ReferenceEquals(existing.Message, message));

        if (existing == null)
            return new IsReadResult.MessageNotFound();

        return existing.IsRead ? new IsReadResult.Read() : new IsReadResult.NotRead();
    }

    public TryMarkAsReadResult TryMarkAsRead(Message message)
    {
        ReceivedMessage? existing = _receivedMessages
            .FirstOrDefault(existing => object.ReferenceEquals(existing.Message, message));

        if (existing == null)
            return new TryMarkAsReadResult.MessageNotFound();

        if (!existing.TryMarkAsRead())
            return new TryMarkAsReadResult.AlreadyWasRead();

        return new TryMarkAsReadResult.Success();
    }
}