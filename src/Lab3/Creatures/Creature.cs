using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class Creature : ICreature
{
    public Health Health { get; protected set; }

    public Attack Attack { get; protected set; }

    protected Creature(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public bool IsAlive() => Health > Health.Zero;

    public bool CanAttack() => Attack > Attack.Zero;

    public virtual void Hit(ICreature target)
    {
        target.Receive(Attack);
    }

    public virtual void Receive(Attack damage)
    {
        Health -= Health.CreateFrom(damage);
    }

    public void Plus(Health health)
    {
        Change(Health + health);
    }

    public void Plus(Attack attack)
    {
        Change(Attack + attack);
    }

    public void Change(Health health)
    {
        if (health <= Health.Zero)
            throw new ArgumentException("Error: health cannot be less than one.");

        Health = health;
    }

    public void Change(Attack attack)
    {
        if (attack <= Attack.Zero)
            throw new ArgumentException("Error: attack cannot be less than one.");

        Attack = attack;
    }

    public abstract ICreature Clone();
}