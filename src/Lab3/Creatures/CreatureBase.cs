using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class CreatureBase : ICreature
{
    public Health Health { get; protected set; }

    public Attack Attack { get; protected set; }

    protected CreatureBase(Health health, Attack attack)
    {
        ChangeHealth(health);
        ChangeAttack(attack);
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

    [MemberNotNull(nameof(Health))]
    public void ChangeHealth(Health health)
    {
        if (health <= Health.Zero)
            throw new ArgumentException("Error: health cannot be less than one.");

        Health = health;
    }

    [MemberNotNull(nameof(Attack))]
    public void ChangeAttack(Attack attack)
    {
        if (attack < Attack.Zero)
            throw new ArgumentException("Error: attack cannot be less than one.");

        Attack = attack;
    }

    public abstract ICreature Clone();
}