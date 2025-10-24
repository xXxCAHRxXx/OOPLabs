namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class ReceivedMessage
{
    public Message Message { get; }

    public bool IsReaded { get; private set; } = false;

    public ReceivedMessage(Message message)
    {
        Message = message;
    }

    public bool TryMarkAsRead()
    {
        if (IsReaded)
            return false;

        IsReaded = true;
        return true;
    }
}