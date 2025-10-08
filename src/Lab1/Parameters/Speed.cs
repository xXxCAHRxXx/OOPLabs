namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed class Speed
{
    public static Speed Zero { get; } = new Speed(0);

    public double Value { get; }

    public Speed(double value)
    {
        Value = value;
    }

    public static Speed CreateFromAccelerationAndTime(Acceleration acceleration, TimeSpan deltaT)
    {
        return new Speed(acceleration.Value * deltaT.TotalSeconds);
    }

    public static Speed operator +(Speed lhs, Speed rhs) => new Speed(lhs.Value + rhs.Value);

    public static bool operator <(Speed lhs, Speed rhs) => lhs.Value > rhs.Value;

    public static bool operator >(Speed lhs, Speed rhs) => rhs < lhs;
}