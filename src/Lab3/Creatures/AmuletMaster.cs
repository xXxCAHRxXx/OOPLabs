using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AmuletMaster : CreatureBase
{
    private AmuletMaster(Health health, Attack attack) : base(health, attack)
    { }

    public static ICreatureBuilder Builder => new AmuletMasterBuilder();

    public override ICreature Clone() => new AmuletMaster(Health, Attack);

    private class AmuletMasterBuilder : BaseCreatureBuilder
    {
        protected override ICreature CreateCreature()
        {
            return new AmuletMaster(
                Health ?? throw new ArgumentNullException("Error: health doesn't have value."),
                Attack ?? throw new ArgumentNullException("Error: attack doesn't have value."));
        }
    }
}