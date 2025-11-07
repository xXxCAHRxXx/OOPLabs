using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public interface ICreatureBuilder : IAttackStep, IHealthStep
{
    ICreatureBuilder AddModificator(IModificatorFactory modificatorFactory);

    ICreature Build();
}