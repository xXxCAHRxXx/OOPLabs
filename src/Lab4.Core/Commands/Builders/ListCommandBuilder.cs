using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class ListCommandBuilder : ICommandBuilder
{
    private int? _depth;

    public ListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public CommandBuilderResultType TryBuild()
    {
        if (_depth is null)
            return new CommandBuilderResultType.Failure(new NotEnoughArgumentsError());

        return new CommandBuilderResultType.Success(new ListCommand(_depth.Value));
    }
}