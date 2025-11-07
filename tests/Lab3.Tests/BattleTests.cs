using Itmo.ObjectOrientedProgramming.Lab3.Battles;
using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class BattleTests
{
    [Fact]
    public void AddCreature_Add7Creatures_NoException()
    {
        Exception? exception = Record.Exception(() => Table.Builder
            .AddCreature(new AmuletMasterBuilderFactory().Create().Build())
            .AddCreature(new CombatAnalystBuilderFactory().Create().Build())
            .AddCreature(new DeathlessHorrorBuilderFactory().Create().Build())
            .AddCreature(new EvilFighterBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .Build());

        Assert.Null(exception);
    }

    [Fact]
    public void AddCreature_Add8Creatures_ThrowException()
    {
        Exception? exception = Record.Exception(() => Table.Builder
            .AddCreature(new AmuletMasterBuilderFactory().Create().Build())
            .AddCreature(new CombatAnalystBuilderFactory().Create().Build())
            .AddCreature(new DeathlessHorrorBuilderFactory().Create().Build())
            .AddCreature(new EvilFighterBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .Build());

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_SpellWorked()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        ITable table = Table.Builder.AddCreature(creature).Build();
        ISpell spell = new PowerPotion();

        TryApplySpellResult result = table.TryApplySpell(creature, spell);
        TryApplySpellResult.Success successResult = Assert.IsType<TryApplySpellResult.Success>(result);
        Assert.Equal(6, successResult.Creature.Attack.Value);
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_SpellWorked_2()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        ITable table = Table.Builder.AddCreature(creature).Build();
        ISpell spell = new ProtectionAmulet();

        TryApplySpellResult result = table.TryApplySpell(creature, spell);
        TryApplySpellResult.Success successResult = Assert.IsType<TryApplySpellResult.Success>(result);

        Assert.IsType<MagicShield>(successResult.Creature);
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_NotFound()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        ITable table = Table.Builder
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .Build();
        ISpell spell = new ProtectionAmulet();

        TryApplySpellResult result = table.TryApplySpell(creature, spell);
        Assert.IsType<TryApplySpellResult.NotFound>(result);
    }

    [Fact]
    public void ChangeDefaulеСharacteristic_AddCreature_GetChangedCreature()
    {
        ICreature creature = new MimicChestBuilderFactory()
            .Create()
            .AddModificatorFactory(new MagicShieldModificatorFactory())
            .WithAttack(new Attack(100))
            .Build();

        Assert.IsType<MagicShield>(creature);
        Attack creatureAttack = creature.Attack;
        Assert.Equal(100, creature.Attack.Value);
    }

    [Fact]
    public void ChangeDefaulеСharacteristicToBad_AddCreature_ThrowException()
    {
        Assert.ThrowsAny<Exception>(() =>
        {
            ICreature creature = new MimicChestBuilderFactory()
                .Create()
                .AddModificatorFactory(new MagicShieldModificatorFactory())
                .WithAttack(new Attack(-1))
                .Build();
        });
    }

    [Fact]
    public void BattleWithEmptyTables_StartFight_Draw()
    {
        ITable table1 = Table.Builder.Build();
        ITable table2 = Table.Builder.Build();

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.Draw>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_FirstWin()
    {
        ITable table1 = Table.Builder
            .AddCreature(new AmuletMasterBuilderFactory().Create().Build())
            .Build();

        ITable table2 = Table.Builder
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .Build();

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.FirstWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin()
    {
        ITable table1 = Table.Builder
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .Build();

        ITable table2 = Table.Builder
            .AddCreature(new DeathlessHorrorBuilderFactory().Create().Build())
            .Build();

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin_2()
    {
        ITable table1 = Table.Builder
            .AddCreature(new MimicChestBuilderFactory().Create().Build())
            .Build();

        ITable table2 = Table.Builder
            .AddCreature(new AmuletMasterBuilderFactory().Create().Build())
            .Build();

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin_3()
    {
        ITable table1 = Table.Builder
            .AddCreature(new MimicChestBuilderFactory().Create().WithHealth(new Health(10)).Build())
            .Build();

        ITable table2 = Table.Builder
            .AddCreature(new AmuletMasterBuilderFactory().Create().Build())
            .Build();

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_TablesNotChanged()
    {
        ICreature creatureTable1 = new MimicChestBuilderFactory().Create().Build();
        ITable table1 = Table.Builder
            .AddCreature(creatureTable1)
            .Build();

        ICreature creatureTable2 = new DeathlessHorrorBuilderFactory().Create().Build();
        ITable table2 = Table.Builder
            .AddCreature(creatureTable2)
            .Build();

        var battle = new Battle(table1, table2);
        battle.StartFight();
        battle.StartFight();
        battle.StartFight();
        Assert.Equal(creatureTable1.Health.Value, new MimicChestBuilderFactory().Create().Build().Health.Value);
        Assert.Equal(creatureTable2.Health.Value, new DeathlessHorrorBuilderFactory().Create().Build().Health.Value);
        Assert.Equal(creatureTable1.Attack.Value, new MimicChestBuilderFactory().Create().Build().Attack.Value);
        Assert.Equal(creatureTable2.Attack.Value, new DeathlessHorrorBuilderFactory().Create().Build().Attack.Value);
    }
}