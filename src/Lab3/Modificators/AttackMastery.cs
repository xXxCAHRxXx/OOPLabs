using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators;

public class AttackMastery : Modificator
{
    public AttackMastery(ICreature creature) : base(creature)
    {
    }

    public override void Hit(ICreature target)
    {
        base.Hit(target);
        if (target.IsAlive())
            base.Hit(target);
    }
}