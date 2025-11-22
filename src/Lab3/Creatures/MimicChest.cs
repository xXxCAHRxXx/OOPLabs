using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : CreatureBase
{
    private MimicChest(Health health, Attack attack) : base(health, attack)
    { }

    public static ICreatureBuilder Builder => new MimicChestBuilder();

    public override void Hit(ICreature target)
    {
        Attack = Attack.Max(Attack, target.Attack);
        Health = Health.Max(Health, target.Health);
        base.Hit(target);
    }

    public override ICreature Clone() => new MimicChest(Health, Attack);

    private class MimicChestBuilder : BaseCreatureBuilder
    {
        protected override ICreature CreateCreature()
        {
            return new MimicChest(
                Health ?? throw new ArgumentNullException("Error: health doesn't have value."),
                Attack ?? throw new ArgumentNullException("Error: attack doesn't have value."));
        }
    }
}