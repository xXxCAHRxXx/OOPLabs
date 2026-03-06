namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.RandomGenerators;

public interface IRandomGenerator
{
    int Generate(int fromInclusive, int toExclusive);
}