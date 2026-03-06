namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class Health
{
    public static Health Zero { get; } = new Health(0);

    public int Value { get; private set; }

    public Health(int value)
    {
        Value = value;
    }

    public static Health CreateFrom(Attack attack)
    {
        return new Health(attack.Value);
    }

    public static Health operator +(Health lhs, Health rhs) => new Health(lhs.Value + rhs.Value);

    public static Health operator -(Health lhs, Health rhs) => new Health(lhs.Value - rhs.Value);

    public static bool operator <(Health lhs, Health rhs) => lhs.Value < rhs.Value;

    public static bool operator >(Health lhs, Health rhs) => rhs < lhs;

    public static bool operator <=(Health lhs, Health rhs) => !(lhs > rhs);

    public static bool operator >=(Health lhs, Health rhs) => rhs <= lhs;

    public static Health Max(Health lhs, Health rhs) => new Health(Math.Max(lhs.Value, rhs.Value));
}