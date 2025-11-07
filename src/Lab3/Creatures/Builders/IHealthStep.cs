using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public interface IHealthStep
{
    IAttackStep WithHealth(Health health);
}