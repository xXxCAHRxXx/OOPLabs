using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionAmulet : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        return new MagicShieldModificatorFactory().CreateCreatureWithModificatorFrom(creature);
    }
}