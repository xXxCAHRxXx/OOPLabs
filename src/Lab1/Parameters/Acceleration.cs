namespace Itmo.ObjectOrientedProgramming.Lab1.Parameters;

public sealed class Acceleration
{
    public static Acceleration Zero { get; } = new Acceleration(0);

    public double Value { get; }

    private Acceleration(double value)
    {
        Value = value;
    }

    public static Acceleration Create(Force force, Mass mass)
    {
        return new Acceleration(force.Value / mass.Value);
    }
}