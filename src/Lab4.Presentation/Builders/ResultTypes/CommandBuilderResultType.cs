using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

public abstract record CommandBuilderResultType
{
    private CommandBuilderResultType() { }

    public sealed record Success(ICommand Command) : CommandBuilderResultType;

    public sealed record Failure(ICommandBuilderError Error) : CommandBuilderResultType;
}