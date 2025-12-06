using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class RenameCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _name;

    public RenameCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public RenameCommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CommandBuilderResultType TryBuild()
    {
        if (_path is null || _name is null)
            return new CommandBuilderResultType.Failure(new NotEnoughArgumentsError());

        return new CommandBuilderResultType.Success(new RenameCommand(_path, _name));
    }
}