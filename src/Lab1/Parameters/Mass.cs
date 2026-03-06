namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed class Mass
{
    public double Value { get; }

    public Mass(double value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Mass value must be greater than zero");

        Value = value;
    }
}