using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class CopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply copy command on disconnected system."));
        }

        string normalizedSourcePath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _sourcePath);

        string normalizedDestinationPath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _destinationPath);

        if (!context.FileSystem.FileExists(normalizedSourcePath))
        {
            return new CommandResultType.Failure(
                new FileNotFoundError($"Error: file {normalizedSourcePath} not exist."));
        }

        if (!context.FileSystem.DirectoryExists(normalizedDestinationPath))
        {
            return new CommandResultType.Failure(
                new DirectoryNotFoundError($"Error: directory {normalizedDestinationPath} do not exist."));
        }

        normalizedDestinationPath = context.FileSystem.Combine(normalizedDestinationPath, context.FileSystem.GetFileName(normalizedSourcePath));

        context.FileSystem.Copy(normalizedSourcePath, normalizedDestinationPath);

        return new CommandResultType.Success();
    }
}