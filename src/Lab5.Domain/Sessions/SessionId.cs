namespace Lab5.Domain.Sessions;

public readonly record struct SessionId(Guid Value)
{
    public static readonly SessionId Default = new(default);
}