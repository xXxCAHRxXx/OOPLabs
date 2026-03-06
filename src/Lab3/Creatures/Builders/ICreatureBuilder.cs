using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder WithHealth(Health health);

    ICreatureBuilder WithAttack(Attack attack);

    ICreatureBuilder AddModificatorFactory(IModificatorFactory modificatorFactory);

    ICreature Build();
}