using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators;

public class MagicShield : ModificatorBase
{
    private bool _shieldActive;

    public MagicShield(ICreature creature) : base(creature)
    {
        _shieldActive = true;
    }

    private MagicShield(ICreature creature, bool shieldActive) : base(creature)
    {
        _shieldActive = shieldActive;
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

    public override ICreature Clone() => new MagicShield(Creature.Clone(), _shieldActive);
}