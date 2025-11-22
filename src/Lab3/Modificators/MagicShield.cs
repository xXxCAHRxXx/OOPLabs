using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators;

public class MagicShield : ModificatorBase
{
    private bool _shieldActive = true;

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

    public override ICreature Clone() => new MagicShield(Creature.Clone());
}