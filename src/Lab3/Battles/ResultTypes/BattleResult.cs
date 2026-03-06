namespace Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultTypes;

public abstract record BattleResult
{
    private BattleResult() { }

    public sealed record FirstWin : BattleResult;

    public sealed record SecondWin : BattleResult;

    public sealed record Draw : BattleResult;
}