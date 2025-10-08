namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed class Distance
{
    public static Distance Zero { get; } = new Distance(0);

    private readonly double _value;

    public Distance(double value)
    {
        _value = value;
    }

    public static Distance CreateFromSpeedAndTime(Speed speed, TimeSpan deltaT)
    {
        return new Distance(speed.Value * deltaT.TotalSeconds);
    }

    public static Distance operator +(Distance lhs, Distance rhs) => new(lhs._value + rhs._value);

    public static bool operator <(Distance lhs, Distance rhs) => lhs._value < rhs._value;

    public static bool operator >(Distance lhs, Distance rhs) => rhs < lhs;

    public static bool operator <=(Distance lhs, Distance rhs) => lhs <= rhs;

    public static bool operator >=(Distance lhs, Distance rhs) => lhs >= rhs;
}
