using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class LoggingAddresseeDecorator : IAddressee
{
    private readonly IAddressee _decoratee;
    private readonly ILogger _logger;

    public LoggingAddresseeDecorator(IAddressee decoratee, ILogger logger)
    {
        _decoratee = decoratee;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        _logger.Log(ArgToLogMessage(message));
        _decoratee.Receive(message);
    }

    private static string ArgToLogMessage(Message message)
    {
        return message.Head;
    }
}