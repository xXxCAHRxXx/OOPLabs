using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

public abstract record GetAttackedCreatureResult
{
    private GetAttackedCreatureResult() { }

    public sealed record Success(ICreature Creature) : GetAttackedCreatureResult;

    public sealed record NotFound : GetAttackedCreatureResult;
}