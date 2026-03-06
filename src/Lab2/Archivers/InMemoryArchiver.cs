using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages = [];

    public void Save(Message message)
    {
        _messages.Add(message);
    }
}