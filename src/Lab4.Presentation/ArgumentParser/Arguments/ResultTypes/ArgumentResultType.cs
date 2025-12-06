namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

public abstract record ArgumentResultType
{
    private ArgumentResultType() { }

    public sealed record Success() : ArgumentResultType;

    public sealed record EndOfParse() : ArgumentResultType;

    public sealed record Failure(IArgumentError Error) : ArgumentResultType;
}