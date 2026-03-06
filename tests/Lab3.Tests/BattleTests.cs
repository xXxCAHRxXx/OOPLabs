using Itmo.ObjectOrientedProgramming.Lab3.Battles;
using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.RandomGenerators;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class BattleTests
{
    private readonly IRandomGenerator _randomGenerator;

    public BattleTests()
    {
        _randomGenerator = Substitute.For<IRandomGenerator>();
        _randomGenerator.Generate(Arg.Any<int>(), Arg.Any<int>()).Returns(0);
    }

    [Fact]
    public void AddCreature_Add8Creatures_SomeNullSomeNotNull()
    {
        var table = new Table(_randomGenerator);
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

        table.AddCreature(creatures[0]);
        AddCreatureResult result = table.AddCreature(creatures[0]);
        Assert.IsType<AddCreatureResult.HasAlreadyBeenAdded>(result);

        for (int i = 1; i < creatures.Length; i++)
        {
            result = table.AddCreature(creatures[i]);

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
        Attack startAttack = creature.Attack;
        var table = new Table(_randomGenerator);
        table.AddCreature(creature);
        var spell = new PowerPotion();

        ICreature? result = table.TryApplySpell(creature, spell);
        Assert.NotNull(result);
        Assert.Equal(startAttack.Value + spell.ValueOfIncreasingAttack.Value, result.Attack.Value);
    }

    [Fact]
    public void TryApplySpell_ApplySpellOnCreature_SpellWorked_2()
    {
        ICreature creature = new MimicChestBuilderFactory().Create().Build();
        var table = new Table(_randomGenerator);
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
        var table = new Table(_randomGenerator);
        table.AddCreature(new MimicChestBuilderFactory().Create().Build());
        ISpell spell = new ProtectionAmulet();

        ICreature? result = table.TryApplySpell(creature, spell);
        Assert.Null(result);
    }

    [Fact]
    public void ChangeDefaulеСharacteristic_AddCreature_GetChangedCreature()
    {
        var newAttack = new Attack(100);
        ICreature creature = new MimicChestBuilderFactory()
            .Create()
            .AddModificatorFactory(new MagicShieldModificatorFactory())
            .WithAttack(newAttack)
            .Build();

        Assert.IsType<MagicShield>(creature);
        Attack creatureAttack = creature.Attack;
        Assert.Equal(newAttack.Value, creature.Attack.Value);
    }

    [Fact]
    public void ChangeDefaulеСharacteristicToUncorrect_AddCreature_ThrowException()
    {
        var newUncorrectAttack = new Attack(-1);
        Assert.ThrowsAny<Exception>(() =>
        {
            ICreature creature = new MimicChestBuilderFactory()
                .Create()
                .AddModificatorFactory(new MagicShieldModificatorFactory())
                .WithAttack(newUncorrectAttack)
                .Build();
        });
    }

    [Fact]
    public void BattleWithEmptyTables_StartFight_Draw()
    {
        var table1 = new Table(_randomGenerator);
        var table2 = new Table(_randomGenerator);

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.Draw>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_FirstWin()
    {
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var table2 = new Table(_randomGenerator);
        table2.AddCreature(new MimicChestBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.FirstWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin()
    {
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(new MimicChestBuilderFactory().Create().Build());

        var table2 = new Table(_randomGenerator);
        table2.AddCreature(new DeathlessHorrorBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin_2()
    {
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(new MimicChestBuilderFactory().Create().Build());

        var table2 = new Table(_randomGenerator);
        table2.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_SecondWin_3()
    {
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(new MimicChestBuilderFactory().Create().WithHealth(new Health(10)).Build());

        var table2 = new Table(_randomGenerator);
        table2.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void SimpleBattle_StartFight_TablesNotChanged()
    {
        ICreature creatureTable1 = new MimicChestBuilderFactory().Create().Build();
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(creatureTable1);

        ICreature creatureTable2 = new DeathlessHorrorBuilderFactory().Create().Build();
        var table2 = new Table(_randomGenerator);
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

    [Fact]
    public void Battle1_StartFight_SecondWin()
    {
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(new MimicChestBuilderFactory().Create().Build());
        table1.AddCreature(new MimicChestBuilderFactory().Create().Build());
        table1.AddCreature(new EvilFighterBuilderFactory().Create().Build());
        table1.AddCreature(new EvilFighterBuilderFactory().Create().Build());

        var table2 = new Table(_randomGenerator);
        table2.AddCreature(new AmuletMasterBuilderFactory().Create().Build());
        table2.AddCreature(new MimicChestBuilderFactory().Create().Build());
        table2.AddCreature(new CombatAnalystBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }

    [Fact]
    public void Battle2_StartFight_SecondWin()
    {
        var table1 = new Table(_randomGenerator);
        table1.AddCreature(new CombatAnalystBuilderFactory().Create().Build());
        table1.AddCreature(new EvilFighterBuilderFactory().Create().Build());
        table1.AddCreature(new AmuletMasterBuilderFactory().Create().Build());

        var table2 = new Table(_randomGenerator);
        table2.AddCreature(new MimicChestBuilderFactory().Create().Build());
        table2.AddCreature(new AmuletMasterBuilderFactory().Create().Build());
        table2.AddCreature(new EvilFighterBuilderFactory().Create().Build());
        table2.AddCreature(new CombatAnalystBuilderFactory().Create().Build());

        var battle = new Battle(table1, table2);
        BattleResult result = battle.StartFight();
        Assert.IsType<BattleResult.SecondWin>(result);
    }
}