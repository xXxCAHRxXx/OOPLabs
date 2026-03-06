namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class ReceivedMessage
{
    public Message Message { get; }

    public bool IsRead { get; private set; } = false;

    public ReceivedMessage(Message message)
    {
        Message = message;
    }

    public bool TryMarkAsRead()
    {
        if (IsRead)
            return false;

        IsRead = true;
        return true;
    }
}