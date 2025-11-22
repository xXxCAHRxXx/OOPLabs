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

    void ChangeHealth(Health health);

    void ChangeAttack(Attack attack);

    ICreature Clone();
}
