using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;

public class MagicShieldModificatorFactory : IModificatorFactory
{
    public ICreature CreateCreatureWithModificatorFrom(ICreature creature)
    {
        return new MagicShield(creature);
    }
}