namespace Lab5.Domain.ValueObjects;

public class PinCode
{
    public int Value { get; }

    public PinCode(int value)
    {
        if (!(value >= 1000 && value < 10000))
            throw new ArgumentOutOfRangeException(nameof(value), value, "Pin code must have 4 digits.");

        Value = value;
    }

    public bool IsEqual(PinCode other) => Value == other.Value;
}