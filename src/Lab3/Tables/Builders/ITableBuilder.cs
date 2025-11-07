using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;

public interface ITableBuilder
{
    ITableBuilder AddCreature(ICreatureBuilderFactory creatureBuilderFactory);

    ITable Build();
}