namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed class Force
{
    public double Value { get; }

    public Force(double value)
    {
        Value = value;
    }

    public bool Exceeds(Force maxAllowedForce)
    {
        return Math.Abs(Value) > maxAllowedForce.Value;
    }
}