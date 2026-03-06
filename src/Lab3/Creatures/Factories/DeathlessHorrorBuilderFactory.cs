using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class DeathlessHorrorBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return DeathlessHorror.Builder
            .WithHealth(new Health(4))
            .WithAttack(new Attack(4));
    }
}