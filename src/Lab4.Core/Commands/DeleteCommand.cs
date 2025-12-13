using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DeleteCommand : ICommand
{
    private readonly string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply delete command on disconnected system."));
        }

        string normalizedPath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _path);

        if (!context.FileSystem.FileExists(normalizedPath))
        {
            return new CommandResultType.Failure(
                new FileNotFoundError($"Error: file {normalizedPath} do not exist."));
        }

        context.FileSystem.Delete(normalizedPath);

        return new CommandResultType.Success();
    }
}