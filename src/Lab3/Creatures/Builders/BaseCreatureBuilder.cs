using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public abstract class BaseCreatureBuilder : ICreatureBuilder
{
    protected Health? Health { get; private set; }

    protected Attack? Attack { get; private set; }

    private readonly Collection<IModificatorFactory> _modificators = new Collection<IModificatorFactory>();

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