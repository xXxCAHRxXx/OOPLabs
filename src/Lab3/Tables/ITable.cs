using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface ITable
{
    GetAttackedCreatureResult GetAttackedCreature();

    GetAttackingCreatureResult GetAttackingCreature();

    TryApplySpellResult TryApplySpell(ICreature creature, ISpell spell);

    ITable Clone();
}