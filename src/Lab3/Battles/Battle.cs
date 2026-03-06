using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

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

            ICreature? attackingCreature = attackingPlayer.FindAttackingCreature();
            ICreature? attackedCreature = attackedPlayer.FindAttackedCreature();

            if (attackingCreature is null && attackedCreature is null)
            {
                return new BattleResult.Draw();
            }

            if (attackingCreature is null)
            {
                isMoveFirstPlayer = !isMoveFirstPlayer;
                continue;
            }

            if (attackedCreature is null)
            {
                return isMoveFirstPlayer ? new BattleResult.FirstWin() : new BattleResult.SecondWin();
            }

            if (attackingCreature is ICreature && attackedCreature is ICreature)
                attackingCreature.Hit(attackedCreature);

            isMoveFirstPlayer = !isMoveFirstPlayer;
        }
    }
}