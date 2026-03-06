using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ListCommand : ICommand
{
    private readonly int _depth;
    private readonly IWriter _writer;

    public ListCommand(int depth, IWriter writer)
    {
        _depth = depth;
        _writer = writer;
    }

    public CommandResultType Execute(IContext context)
    {
        if (context.FileSystem is null)
        {
            return new CommandResultType.Failure(
                new DisconnectError($"Error: try to apply list command on disconnected system."));
        }

        var visitor = new FormattingVisitor(context.FileSystem, _writer, "F: ", "D: ", "  ");
        var component = new DirectoryFileSystemComponent(context.LocalPath);
        component.Accept(visitor, 0, _depth);

        return new CommandResultType.Success();
    }
}