using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.RandomGenerators;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class Table : ITable
{
    public int MaxCreaturesCount { get; } = 7;

    private readonly List<ICreature> _creatures;
    private readonly IRandomGenerator _randomGenerator;

    public Table(IRandomGenerator randomGenerator)
    {
        _randomGenerator = randomGenerator;
        _creatures = new List<ICreature>();
    }

    private Table(List<ICreature> creatures, IRandomGenerator randomGenerator)
    {
        _creatures = creatures;
        _randomGenerator = randomGenerator;
    }

    public AddCreatureResult AddCreature(ICreature creature)
    {
        if (_creatures.Count == MaxCreaturesCount)
            return new AddCreatureResult.MoreThanMaxCreaturesCountWasAdded();

        if (_creatures.Any(curCreature => ReferenceEquals(curCreature, creature)))
            return new AddCreatureResult.HasAlreadyBeenAdded();

        _creatures.Add(creature);
        return new AddCreatureResult.Success();
    }

    public ICreature? FindAttackedCreature()
    {
        var mayBeAttackedCreatures = _creatures.Where(curCreature => curCreature.IsAlive()).ToList();
        if (mayBeAttackedCreatures.Count == 0)
            return null;

        ICreature mayBeAttackedCreature = mayBeAttackedCreatures[_randomGenerator.Generate(0, mayBeAttackedCreatures.Count)];
        return mayBeAttackedCreature;
    }

    public ICreature? FindAttackingCreature()
    {
        var ableToAttackCreatures = _creatures.Where(curCreature => curCreature.IsAlive() && curCreature.CanAttack()).ToList();
        if (ableToAttackCreatures.Count == 0)
            return null;

        ICreature ableToAttackCreature = ableToAttackCreatures[_randomGenerator.Generate(0, ableToAttackCreatures.Count)];
        return ableToAttackCreature;
    }

    public ICreature? TryApplySpell(ICreature creature, ISpell spell)
    {
        ICreature? target = _creatures.FirstOrDefault(curCreature => ReferenceEquals(curCreature, creature));
        if (target == null)
            return null;

        ICreature creatureWithSpell = spell.Apply(target);

        _creatures[_creatures.IndexOf(target)] = creatureWithSpell;

        return creatureWithSpell;
    }

    public ITable Clone()
    {
        var clonedCreatures = _creatures.Select(curCreature => curCreature.Clone()).ToList();

        return new Table(clonedCreatures, _randomGenerator);
    }
}