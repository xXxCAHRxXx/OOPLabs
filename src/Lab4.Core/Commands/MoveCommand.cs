using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class MoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply move command on disconnected system."));
        }

        string normalizedSourcePath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _sourcePath);

        string normalizedDestinationPath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _destinationPath);

        if (!context.FileSystem.FileExists(normalizedSourcePath))
        {
            return new CommandResultType.Failure(
                new FileNotFoundError($"Error: file {normalizedSourcePath} do not exist."));
        }

        if (!context.FileSystem.DirectoryExists(normalizedDestinationPath))
        {
            return new CommandResultType.Failure(
                new DirectoryNotFoundError($"Error: file {normalizedDestinationPath} do not exist."));
        }

        normalizedDestinationPath = context.FileSystem.Combine(normalizedDestinationPath, context.FileSystem.GetFileName(normalizedSourcePath));

        context.FileSystem.Move(normalizedSourcePath, normalizedDestinationPath);

        return new CommandResultType.Success();
    }
}