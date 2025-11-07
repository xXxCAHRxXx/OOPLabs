using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators;

public abstract class Modificator : ICreature
{
    protected ICreature Creature { get; }

    protected Modificator(ICreature creature)
    {
        Creature = creature;
    }

    public Attack Attack => Creature.Attack;

    public Health Health => Creature.Health;

    public bool IsAlive() => Creature.IsAlive();

    public bool CanAttack() => Creature.CanAttack();

    public virtual void Hit(ICreature target) => Creature.Hit(target);

    public virtual void Receive(Attack damage) => Creature.Receive(damage);

    public void Plus(Health health) => Creature.Plus(health);

    public void Plus(Attack attack) => Creature.Plus(attack);

    public void Change(Health health) => Creature.Change(health);

    public void Change(Attack attack) => Creature.Change(attack);

    public ICreature Clone() => Creature.Clone();
}