using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        creature.ChangeHealth(creature.Health + new Health(5));
        return creature;
    }
}