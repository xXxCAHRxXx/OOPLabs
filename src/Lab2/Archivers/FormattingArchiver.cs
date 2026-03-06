using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivers;

public class FormattingArchiver : IArchiver
{
    private readonly IFormatter _formatter;

    public FormattingArchiver(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Save(Message message)
    {
        _formatter.WriteHead(message.Head);
        _formatter.WriteBody(message.Body);
    }
}