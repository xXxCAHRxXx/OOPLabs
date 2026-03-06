using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;

public interface IModificatorFactory
{
    ICreature CreateCreatureWithModificatorFrom(ICreature creature);
}