using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class RenameCommand : BaseCommand
{
    private readonly string _path;
    private readonly string _name;

    public RenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public override CommandResultType Execute(IContextFileSystem contextFileSystem)
    {
        try
        {
            contextFileSystem.Rename(_path, _name);
        }
        catch (Exception exception)
        {
            return new CommandResultType.Failure(GetErrorFromException(exception));
        }

        return new CommandResultType.Success();
    }
}