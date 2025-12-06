using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DeleteCommand : BaseCommand
{
    private readonly string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public override CommandResultType Execute(IContextFileSystem contextFileSystem)
    {
        try
        {
            contextFileSystem.Delete(_path);
        }
        catch (Exception exception)
        {
            return new CommandResultType.Failure(GetErrorFromException(exception));
        }

        return new CommandResultType.Success();
    }
}