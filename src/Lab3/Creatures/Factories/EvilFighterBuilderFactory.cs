using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class EvilFighterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder Create()
    {
        return EvilFighter.Builder
            .WithHealth(new Health(6))
            .WithAttack(new Attack(1));
    }
}