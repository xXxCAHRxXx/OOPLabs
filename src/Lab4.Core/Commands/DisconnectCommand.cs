using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : BaseCommand
{
    public override CommandResultType Execute(IContextFileSystem contextFileSystem)
    {
        try
        {
            contextFileSystem.Disconnect();
        }
        catch (Exception exception)
        {
            return new CommandResultType.Failure(GetErrorFromException(exception));
        }

        return new CommandResultType.Success();
    }
}