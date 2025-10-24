namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public abstract record ImportanceLevel : IComparable<ImportanceLevel>
{
    private readonly int _importanceValue;

    protected ImportanceLevel(int importanceValue)
    {
        _importanceValue = importanceValue;
    }

    public sealed record Low() : ImportanceLevel(0);

    public sealed record Medium() : ImportanceLevel(1);

    public sealed record High() : ImportanceLevel(2);

    public int CompareTo(ImportanceLevel? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;

        return _importanceValue.CompareTo(other._importanceValue);
    }
}