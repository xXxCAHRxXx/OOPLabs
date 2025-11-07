using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class Table : ITable
{
    private readonly List<ICreature> _creatures;

    private Table(List<ICreature> creatures)
    {
        _creatures = creatures;
    }

    public static ITableBuilder Builder => new TableBuilder();

    public GetAttackedCreatureResult GetAttackedCreature()
    {
        var mayBeAttackedCreatures = _creatures.Where(curCreature => curCreature.IsAlive()).ToList();
        if (mayBeAttackedCreatures.Count == 0)
            return new GetAttackedCreatureResult.NotFound();

        ICreature mayBeAttackedCreature = mayBeAttackedCreatures[RandomNumberGenerator.GetInt32(mayBeAttackedCreatures.Count)];
        return new GetAttackedCreatureResult.Success(mayBeAttackedCreature);
    }

    public GetAttackingCreatureResult GetAttackingCreature()
    {
        var ableToAttackCreatures = _creatures.Where(curCreature => curCreature.IsAlive() && curCreature.CanAttack()).ToList();
        if (ableToAttackCreatures.Count == 0)
            return new GetAttackingCreatureResult.NotFound();

        ICreature ableToAttackCreature = ableToAttackCreatures[RandomNumberGenerator.GetInt32(ableToAttackCreatures.Count)];
        return new GetAttackingCreatureResult.Success(ableToAttackCreature);
    }

    public TryApplySpellResult TryApplySpell(ICreature creature, ISpell spell)
    {
        ICreature? target = _creatures.FirstOrDefault(curCreature => ReferenceEquals(curCreature, creature));
        if (target == null)
            return new TryApplySpellResult.NotFound();

        ICreature creatureWithSpell = spell.Apply(target);

        _creatures[_creatures.IndexOf(target)] = creatureWithSpell;

        return new TryApplySpellResult.Success(creatureWithSpell);
    }

    public ITable Clone()
    {
        var clonedCreatures = _creatures.Select(curCreature => curCreature.Clone()).ToList();

        return new Table(clonedCreatures);
    }

    private class TableBuilder : ITableBuilder
    {
        private const int MaxCreaturesCount = 7;

        private readonly List<ICreature> _creatures = new List<ICreature>();

        public ITableBuilder AddCreature(ICreature creatureBuilder)
        {
            if (_creatures.Count is MaxCreaturesCount)
                throw new ArgumentException("Error: add more than 7 creatures in builder.");

            _creatures.Add(creatureBuilder);
            return this;
        }

        public ITable Build()
        {
            return new Table(_creatures);
        }
    }
}