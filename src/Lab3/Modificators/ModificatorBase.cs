using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators;

public abstract class ModificatorBase : ICreature
{
    protected ICreature Creature { get; }

    protected ModificatorBase(ICreature creature)
    {
        Creature = creature;
    }

    public Attack Attack => Creature.Attack;

    public Health Health => Creature.Health;

    public bool IsAlive() => Creature.IsAlive();

    public bool CanAttack() => Creature.CanAttack();

    public virtual void Hit(ICreature target) => Creature.Hit(target);

    public virtual void Receive(Attack damage) => Creature.Receive(damage);

    public void ChangeHealth(Health health) => Creature.ChangeHealth(health);

    public void ChangeAttack(Attack attack) => Creature.ChangeAttack(attack);

    public abstract ICreature Clone();
}