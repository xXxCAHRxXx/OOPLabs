using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ShowCommand : ICommand
{
    private readonly string _path;
    private readonly IWriter _writer;

    public ShowCommand(string path, IWriter writer)
    {
        _path = path;
        _writer = writer;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply show command on disconnected system."));
        }

        string normalizedPath = context.FileSystem
            .Combine(context.ConnectionPath, context.LocalPath, _path);

        if (!context.FileSystem.FileExists(normalizedPath))
        {
            return new CommandResultType.Failure(
                new FileNotFoundError($"Error: file {normalizedPath} do not exist."));
        }

        string fileText = context.FileSystem.ReadAllText(normalizedPath);
        _writer.Write(fileText);

        return new CommandResultType.Success();
    }
}