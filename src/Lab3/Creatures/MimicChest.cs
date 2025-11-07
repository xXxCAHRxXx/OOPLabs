using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : Creature
{
    private MimicChest(Health health, Attack attack) : base(health, attack)
    { }

    public static IHealthStep Builder => new MimicChestBuilder();

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
            return new MimicChest(Health, Attack);
        }
    }
}