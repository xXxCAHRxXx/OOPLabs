using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public abstract class CreatureBaseBuilder : ICreatureBuilder
{
    protected Health? Health { get; private set; }

    protected Attack? Attack { get; private set; }

    private readonly List<IModificatorFactory> _modificators = new List<IModificatorFactory>();

    public ICreatureBuilder WithHealth(Health health)
    {
        Health = health;
        return this;
    }

    public ICreatureBuilder WithAttack(Attack attack)
    {
        Attack = attack;
        return this;
    }

    public ICreatureBuilder AddModificatorFactory(IModificatorFactory modificatorFactory)
    {
        _modificators.Add(modificatorFactory);
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = CreateCreature();
        ICreature creatureWithMods = _modificators.Aggregate(
            creature,
            (curCreature, factory) => factory.CreateCreatureWithModificatorFrom(curCreature));

        return creatureWithMods;
    }

    protected abstract ICreature CreateCreature();
}