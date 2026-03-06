using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    public Health ValueOfIncreasingHealth { get; } = new Health(5);

    public ICreature Apply(ICreature creature)
    {
        creature.ChangeHealth(creature.Health + ValueOfIncreasingHealth);
        return creature;
    }
}