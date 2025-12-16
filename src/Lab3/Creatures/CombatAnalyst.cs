using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : CreatureBase
{
    private readonly Attack _increaseAttackBeforeHit = new Attack(2);

    private CombatAnalyst(Health health, Attack attack) : base(health, attack)
    { }

    public static ICreatureBuilder Builder => new CombatAnalystBuilder();

    public override void Hit(ICreature target)
    {
        Attack += _increaseAttackBeforeHit;
        base.Hit(target);
    }

    public override ICreature Clone() => new CombatAnalyst(Health, Attack);

    private class CombatAnalystBuilder : CreatureBuilderBase
    {
        protected override ICreature CreateCreature()
        {
            return new CombatAnalyst(
                Health ?? throw new ArgumentNullException("Error: health doesn't have value."),
                Attack ?? throw new ArgumentNullException("Error: attack doesn't have value."));
        }
    }
}