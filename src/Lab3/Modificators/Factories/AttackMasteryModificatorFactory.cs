using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;

public class AttackMasteryModificatorFactory : IModificatorFactory
{
    public ICreature CreateModificatorFrom(ICreature creature)
    {
        return new AttackMastery(creature);
    }
}