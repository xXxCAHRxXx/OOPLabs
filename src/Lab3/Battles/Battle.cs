using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battles;

public class Battle : IBattle
{
    private readonly ITable _table1;
    private readonly ITable _table2;

    public Battle(ITable table1, ITable table2)
    {
        _table1 = table1;
        _table2 = table2;
    }

    public BattleResult StartFight()
    {
        ITable player1 = _table1.Clone();
        ITable player2 = _table2.Clone();

        bool isMoveFirstPlayer = true;
        while (true)
        {
            ITable attackingPlayer = isMoveFirstPlayer ? player1 : player2;
            ITable attackedPlayer = isMoveFirstPlayer ? player2 : player1;

            GetAttackingCreatureResult getAttackingCreatureResult = attackingPlayer.GetAttackingCreature();
            GetAttackedCreatureResult getAttackedCreatureResult = attackedPlayer.GetAttackedCreature();

            if (getAttackingCreatureResult is GetAttackingCreatureResult.NotFound &&
                getAttackedCreatureResult is GetAttackedCreatureResult.NotFound)
            {
                return new BattleResult.Draw();
            }

            if (getAttackingCreatureResult is not GetAttackingCreatureResult.Success attackingPlayerSuccess)
            {
                isMoveFirstPlayer = !isMoveFirstPlayer;
                continue;
            }

            if (getAttackedCreatureResult is not GetAttackedCreatureResult.Success attackedPlayerSuccess)
            {
                return isMoveFirstPlayer ? new BattleResult.FirstWin() : new BattleResult.SecondWin();
            }

            ICreature attackingCreature = attackingPlayerSuccess.Creature;
            ICreature attackedCreature = attackedPlayerSuccess.Creature;

            attackingCreature.Hit(attackedCreature);

            isMoveFirstPlayer = !isMoveFirstPlayer;
        }
    }
}