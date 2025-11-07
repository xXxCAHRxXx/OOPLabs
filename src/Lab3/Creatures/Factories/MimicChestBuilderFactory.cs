using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class MimicChestBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return MimicChest.Builder
            .WithHealth(new Health(1))
            .WithAttack(new Attack(1));
    }
}