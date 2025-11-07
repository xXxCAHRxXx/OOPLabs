using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        Attack attack = creature.Attack;
        Health health = creature.Health;
        creature.Change(Health.CreateFrom(attack));
        creature.Change(Attack.CreateFrom(health));
        return creature;
    }
}