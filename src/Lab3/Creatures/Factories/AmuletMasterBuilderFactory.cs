using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class AmuletMasterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return AmuletMaster.Builder
            .WithHealth(new Health(5))
            .WithAttack(new Attack(2))
            .AddModificator(new MagicShieldModificatorFactory())
            .AddModificator(new AttackMasteryModificatorFactory());
    }
}