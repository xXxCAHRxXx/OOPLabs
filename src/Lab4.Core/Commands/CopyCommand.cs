using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class CopyCommand : BaseCommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public override CommandResultType Execute(IContextFileSystem contextFileSystem)
    {
        try
        {
            contextFileSystem.Copy(_sourcePath, _destinationPath);
        }
        catch (Exception exception)
        {
            return new CommandResultType.Failure(GetErrorFromException(exception));
        }

        return new CommandResultType.Success();
    }
}