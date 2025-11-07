using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public interface IAttackStep
{
    ICreatureBuilder WithAttack(Attack attack);
}