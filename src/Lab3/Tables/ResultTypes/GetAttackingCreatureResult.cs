using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

public record GetAttackingCreatureResult
{
    private GetAttackingCreatureResult() { }

    public sealed record Success(ICreature Creature) : GetAttackingCreatureResult;

    public sealed record NotFound : GetAttackingCreatureResult;
}