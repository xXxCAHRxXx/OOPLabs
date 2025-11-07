namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class Attack
{
    public static Attack Zero { get; } = new Attack(0);

    public int Value { get; }

    public Attack(int value)
    {
        Value = value;
    }

    public static Attack CreateFrom(Health health)
    {
        return new Attack(health.Value);
    }

    public static Attack operator +(Attack lhs, Attack rhs) => new Attack(lhs.Value + rhs.Value);

    public static Attack operator -(Attack lhs, Attack rhs) => new Attack(lhs.Value - rhs.Value);

    public static bool operator <(Attack lhs, Attack rhs) => lhs.Value < rhs.Value;

    public static bool operator >(Attack lhs, Attack rhs) => rhs < lhs;

    public static bool operator <=(Attack lhs, Attack rhs) => !(lhs > rhs);

    public static bool operator >=(Attack lhs, Attack rhs) => rhs <= lhs;

    public static Attack Max(Attack lhs, Attack rhs) => new Attack(Math.Max(lhs.Value, rhs.Value));
}