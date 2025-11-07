using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    Health Health { get; }

    Attack Attack { get; }

    bool IsAlive();

    bool CanAttack();

    void Hit(ICreature target);

    void Receive(Attack damage);

    void Plus(Health health);

    void Plus(Attack attack);

    void Change(Health health);

    void Change(Attack attack);

    ICreature Clone();
}
