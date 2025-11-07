using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class CombatAnalystBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return CombatAnalyst.Builder
            .WithHealth(new Health(4))
            .WithAttack(new Attack(2));
    }
}