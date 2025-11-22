using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    public Attack ValueOfIncreasingAttack { get; } = new Attack(5);

    public ICreature Apply(ICreature creature)
    {
        creature.ChangeAttack(creature.Attack + ValueOfIncreasingAttack);
        return creature;
    }
}