using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        creature.ChangeAttack(creature.Attack + new Attack(5));
        return creature;
    }
}