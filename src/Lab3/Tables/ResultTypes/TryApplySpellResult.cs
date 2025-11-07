using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

public abstract record TryApplySpellResult
{
    private TryApplySpellResult() { }

    public sealed record Success(ICreature Creature) : TryApplySpellResult;

    public sealed record NotFound : TryApplySpellResult;
}