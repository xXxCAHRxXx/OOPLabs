using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : Creature
{
    private EvilFighter(Health health, Attack attack) : base(health, attack)
    { }

    public static IHealthStep Builder => new EvilFighterBuilder();

    public override void Receive(Attack damage)
    {
        base.Receive(damage);
        if (Health - Health.CreateFrom(damage) > Health.Zero)
            Attack += Attack;
    }

    public override ICreature Clone() => new EvilFighter(Health, Attack);

    private class EvilFighterBuilder : BaseCreatureBuilder
    {
        protected override ICreature CreateCreature()
        {
            return new EvilFighter(Health, Attack);
        }
    }
}