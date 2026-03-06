namespace Lab5.Domain.ValueObjects;

public class Password
{
    public string Value { get; }

    public Password(string value)
    {
        Value = value;
    }

    public bool IsEqual(Password other) => Value == other.Value;
}