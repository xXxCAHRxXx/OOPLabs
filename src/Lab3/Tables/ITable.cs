using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface ITable
{
    GetAttackedCreatureResult GetAttackedCreature();

    GetAttackingCreatureResult GetAttackingCreature();

    ITable Clone();
}