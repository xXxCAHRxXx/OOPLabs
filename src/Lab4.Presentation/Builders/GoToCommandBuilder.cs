using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

public class GoToCommandBuilder : ICommandBuilder
{
    private string? _path;

    public GoToCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public CommandBuilderResultType TryBuild()
    {
        if (_path is null)
            return new CommandBuilderResultType.Failure(new NotEnoughArgumentsError());

        return new CommandBuilderResultType.Success(new GoToCommand(_path));
    }
}