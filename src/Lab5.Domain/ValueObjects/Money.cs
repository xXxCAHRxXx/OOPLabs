namespace Lab5.Domain.ValueObjects;

public class Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
    }

    public static Money Zero => new Money(0);

    public static bool operator <(Money lhs, Money rhs) => lhs.Value < rhs.Value;

    public static bool operator >(Money lhs, Money rhs) => rhs < lhs;

    public static bool operator <=(Money lhs, Money rhs) => !(lhs > rhs);

    public static bool operator >=(Money lhs, Money rhs) => rhs <= lhs;

    public static Money operator +(Money lhs, Money rhs) => new Money(lhs.Value + rhs.Value);

    public static Money operator -(Money lhs, Money rhs) => new Money(lhs.Value - rhs.Value);
}