using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class RenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public RenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply rename command on disconnected system."));
        }

        string normalizedPath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _path);

        if (!context.FileSystem.FileExists(normalizedPath))
        {
            return new CommandResultType.Failure(
                new FileNotFoundError($"Error: file {normalizedPath} do not exist."));
        }

        string directoryName = context.FileSystem.GetDirectoryName(normalizedPath) ?? string.Empty;
        string newRenamedPath = context.FileSystem.Combine(directoryName, _name);

        if (directoryName != context.FileSystem.GetDirectoryName(newRenamedPath))
        {
            return new CommandResultType.Failure(
                new WrongFileNameError($"Error: file {_name} has wrong name."));
        }

        if (context.FileSystem.FileExists(newRenamedPath))
        {
            return new CommandResultType.Failure(
                new FileAlreadyExistsError($"Error: file {newRenamedPath} already exists."));
        }

        context.FileSystem.Move(normalizedPath, newRenamedPath);

        return new CommandResultType.Success();
    }
}