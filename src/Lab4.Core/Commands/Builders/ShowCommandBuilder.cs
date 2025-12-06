using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class ShowCommandBuilder : ICommandBuilder
{
    private string? _path;
    private IWriter? _writer;

    public ShowCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ShowCommandBuilder WithWriter(IWriter writer)
    {
        _writer = writer;
        return this;
    }

    public CommandBuilderResultType TryBuild()
    {
        if (_path is null || _writer is null)
            return new CommandBuilderResultType.Failure(new NotEnoughArgumentsError());

        return new CommandBuilderResultType.Success(new ShowCommand(_path, _writer));
    }
}