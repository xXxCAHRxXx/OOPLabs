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
    public void AddCreature_Add8Creatures_SomeNullSomeNotNull()
    {
        var table = new Table();
        var creatures = new ICreature[]
        {
            new AmuletMasterBuilderFactory().Create().Build(),
            new CombatAnalystBuilderFactory().Create().Build(),
            new DeathlessHorrorBuilderFactory().Create().Build(),
            new EvilFighterBuilderFactory().Create().Build(),
            new MimicChestBuilderFactory().Create().Build(),
            new MimicChestBuilderFactory().Create().Build(),
            new MimicChestBuilderFactory().Create().Build(),
            new MimicChestBuilderFactory().Create().Build(),
        };

        for (int i = 0; i < creatures.Length; i++)
        {
            AddCreatureResult result = table.AddCreature(creatures[i]);

            if (i < table.MaxCreaturesCount)
            {
                Assert.IsType<AddCreatureResult.Success>(result);
            }
            else
            {
                Assert.IsType<AddCreatureResult.MoreThanMaxCreaturesCountWasAdded>(result);
            }
        }
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_SpellWorked()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        var table = new Table();
        table.AddCreature(creature);
        ISpell spell = new PowerPotion();

        ICreature? result = table.TryApplySpell(creature, spell);
        Assert.NotNull(result);
        Assert.Equal(6, result.Attack.Value);
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_SpellWorked_2()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        var table = new Table();
        table.AddCreature(creature);
        ISpell spell = new ProtectionAmulet();

        ICreature? result = table.TryApplySpell(creature, spell);
        Assert.NotNull(result);

        Assert.IsType<MagicShield>(result);
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_NotFound()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        var table = new Table();
        table.AddCreature(new MimicChestBuilderFactory().Create().Build());
        ISpell spell = new ProtectionAmulet();

        ICreature? result = table.TryApplySpell(creature, spell);
        Assert.Null(result);
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
        var table1 = new Table();
        var table2 = new Table();

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.Draw>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_FirstWin()
    {
        var table1 = new Table();
        table1.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var table2 = new Table();
        table2.AddCreature(new MimicChestBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.FirstWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin()
    {
        var table1 = new Table();
        table1.AddCreature(new MimicChestBuilderFactory().Create().Build());

        var table2 = new Table();
        table2.AddCreature(new DeathlessHorrorBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin_2()
    {
        var table1 = new Table();
        table1.AddCreature(new MimicChestBuilderFactory().Create().Build());

        var table2 = new Table();
        table2.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin_3()
    {
        var table1 = new Table();
        table1.AddCreature(new MimicChestBuilderFactory().Create().WithHealth(new Health(10)).Build());

        var table2 = new Table();
        table2.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_TablesNotChanged()
    {
        ICreature creatureTable1 = new MimicChestBuilderFactory().Create().Build();
        var table1 = new Table();
        table1.AddCreature(creatureTable1);

        ICreature creatureTable2 = new DeathlessHorrorBuilderFactory().Create().Build();
        var table2 = new Table();
        table2.AddCreature(creatureTable2);

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