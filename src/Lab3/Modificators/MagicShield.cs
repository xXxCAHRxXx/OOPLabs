using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators;

public class MagicShield : Modificator
{
    private bool _shieldActive = false;

    public MagicShield(ICreature creature) : base(creature)
    {
    }

    public override void Receive(Attack damage)
    {
        if (_shieldActive)
        {
            _shieldActive = false;
        }
        else
        {
            base.Receive(damage);
        }
    }
}