using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface ITable
{
    AddCreatureResult AddCreature(ICreature creature);

    ICreature? FindAttackedCreature();

    ICreature? FindAttackingCreature();

    ICreature? TryApplySpell(ICreature creature, ISpell spell);

    ITable Clone();
}