using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class GoToCommand : ICommand
{
    private readonly string _path;

    public GoToCommand(string path)
    {
        _path = path;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply goto command on disconnected system."));
        }

        string normalizedPath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _path);
        string newLocalPath = context.FileSystem.Combine(context.ConnectionPath, context.LocalPath, normalizedPath);

        if (!context.FileSystem.DirectoryExists(newLocalPath))
        {
            return new CommandResultType.Failure(
                new DirectoryNotFoundError($"Error: directory {newLocalPath} does not exist."));
        }

        if (!context.FileSystem.IsSubDirectory(context.ConnectionPath, newLocalPath))
        {
            return new CommandResultType.Failure(
                new ChangeLocalPathError(
                    $"Error: new local path {newLocalPath} is not a subdirectory of {context.ConnectionPath}."));
        }

        context.ChangeLocalPath(newLocalPath);

        return new CommandResultType.Success();
    }
}