using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class DeathlessHorror : Creature
{
    private readonly Health _healthAfterRevived = new Health(1);

    private bool wasRevived = false;

    private DeathlessHorror(Health health, Attack attack) : base(health, attack)
    { }

    public static ICreatureBuilder Builder => new DeathlessHorrorBuilder();

    public override void Receive(Attack damage)
    {
        base.Receive(damage);
        if (!wasRevived && !IsAlive())
        {
            wasRevived = true;
            Health = _healthAfterRevived;
        }
    }

    public override ICreature Clone() => new DeathlessHorror(Health, Attack);

    private class DeathlessHorrorBuilder : BaseCreatureBuilder
    {
        protected override ICreature CreateCreature()
        {
            return new DeathlessHorror(
                Health ?? throw new NullReferenceException("Error: health doesn't have value."),
                Attack ?? throw new NullReferenceException("Error: attack doesn't have value."));
        }
    }
}