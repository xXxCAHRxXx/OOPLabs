namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

public abstract record AddCreatureResult
{
    private AddCreatureResult() { }

    public sealed record Success : AddCreatureResult;

    public sealed record HasAlreadyBeenAdded : AddCreatureResult;

    public sealed record MoreThanMaxCreaturesCountWasAdded : AddCreatureResult;
}