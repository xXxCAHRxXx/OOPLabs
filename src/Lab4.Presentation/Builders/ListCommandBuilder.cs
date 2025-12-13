using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

public class ListCommandBuilder : ICommandBuilder
{
    private int? _depth;
    private IWriter? _writer = new ConsoleWriter();

    public ListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ListCommandBuilder WithWriter(IWriter writer)
    {
        _writer = writer;
        return this;
    }

    public CommandBuilderResultType TryBuild()
    {
        if (_depth is null || _writer is null)
            return new CommandBuilderResultType.Failure(new NotEnoughArgumentsError());

        return new CommandBuilderResultType.Success(new ListCommand(_depth.Value, _writer));
    }
}