using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ListCommand : BaseCommand
{
    private readonly int _depth;

    public ListCommand(int depth)
    {
        _depth = depth;
    }

    public override CommandResultType Execute(IContextFileSystem contextFileSystem)
    {
        try
        {
            contextFileSystem.TreeList(_depth);
        }
        catch (Exception exception)
        {
            return new CommandResultType.Failure(GetErrorFromException(exception));
        }

        return new CommandResultType.Success();
    }
}