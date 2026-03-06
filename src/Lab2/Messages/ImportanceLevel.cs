namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public sealed record ImportanceLevel : IComparable<ImportanceLevel>
{
    private readonly int _importanceValue;

    private ImportanceLevel(int importanceValue)
    {
        _importanceValue = importanceValue;
    }

    public static ImportanceLevel Low()
    {
        return new ImportanceLevel(0);
    }

    public static ImportanceLevel Medium()
    {
        return new ImportanceLevel(1);
    }

    public static ImportanceLevel High()
    {
        return new ImportanceLevel(2);
    }

    public int CompareTo(ImportanceLevel? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;

        return _importanceValue.CompareTo(other._importanceValue);
    }
}