namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public abstract record CommandResultType
{
    public sealed record Success : CommandResultType;

    public sealed record Failure(ICommandError Error) : CommandResultType;
}