using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : Creature
{
    private readonly Attack _increaseAttackBeforeHit = new Attack(2);

    private CombatAnalyst(Health health, Attack attack) : base(health, attack)
    { }

    public static IHealthStep Builder => new CombatAnalystBuilder();

    public override void Hit(ICreature target)
    {
        Attack += _increaseAttackBeforeHit;
        base.Hit(target);
    }

    public override ICreature Clone() => new CombatAnalyst(Health, Attack);

    private class CombatAnalystBuilder : BaseCreatureBuilder
    {
        protected override ICreature CreateCreature()
        {
            return new CombatAnalyst(Health, Attack);
        }
    }
}