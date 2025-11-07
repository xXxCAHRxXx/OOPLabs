using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;

public interface IModificatorFactory
{
    ICreature CreateModificatorFrom(ICreature creature);
}