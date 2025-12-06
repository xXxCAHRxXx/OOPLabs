using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public abstract class BaseCommand : ICommand
{
    public abstract CommandResultType Execute(IContextFileSystem contextFileSystem);

    public ICommandError GetErrorFromException(Exception exception)
    {
        return exception switch
        {
            DirectoryNotFoundException => new DirectoryNotFoundError(exception.Message),
            FileNotFoundException => new FileNotFoundError(exception.Message),
            DisconnectException => new DisconnectError(exception.Message),
            InvalidOperationException => new InvalidOperationError(exception.Message),
            _ => new FileSystemError(exception.Message),
        };
    }
}