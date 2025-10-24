namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public string Head { get; }

    public string Body { get; }

    public ImportanceLevel ImportanceLevel { get; }

    public Message(string head, string body, ImportanceLevel importanceLevel)
    {
        Head = head;
        Body = body;
        ImportanceLevel = importanceLevel;
    }
}