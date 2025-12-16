using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : CreatureBase
{
    private EvilFighter(Health health, Attack attack) : base(health, attack)
    { }

    public static ICreatureBuilder Builder => new EvilFighterBuilder();

    public override void Receive(Attack damage)
    {
        base.Receive(damage);
        if (Health - Health.CreateFrom(damage) > Health.Zero)
            Attack += Attack;
    }

    public override ICreature Clone() => new EvilFighter(Health, Attack);

    private class EvilFighterBuilder : CreatureBuilderBase
    {
        protected override ICreature CreateCreature()
        {
            return new EvilFighter(
                Health ?? throw new ArgumentNullException("Error: health doesn't have value."),
                Attack ?? throw new ArgumentNullException("Error: attack doesn't have value."));
        }
    }
}