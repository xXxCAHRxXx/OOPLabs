using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class DeathlessHorror : CreatureBase
{
    private readonly Health _healthAfterRevived = new Health(1);

    private bool _wasRevived;

    private DeathlessHorror(Health health, Attack attack) : base(health, attack)
    {
        _wasRevived = false;
    }

    private DeathlessHorror(Health health, Attack attack, bool wasRevived) : base(health, attack)
    {
        _wasRevived = wasRevived;
    }

    public static ICreatureBuilder Builder => new DeathlessHorrorBuilder();

    public override void Receive(Attack damage)
    {
        base.Receive(damage);
        if (!_wasRevived && !IsAlive())
        {
            _wasRevived = true;
            Health = _healthAfterRevived;
        }
    }

    public override ICreature Clone() => new DeathlessHorror(Health, Attack, _wasRevived);

    private class DeathlessHorrorBuilder : CreatureBuilderBase
    {
        protected override ICreature CreateCreature()
        {
            return new DeathlessHorror(
                Health ?? throw new ArgumentNullException("Error: health doesn't have value."),
                Attack ?? throw new ArgumentNullException("Error: attack doesn't have value."));
        }
    }
}