namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public record TryMarkAsReadResult
{
    private TryMarkAsReadResult() { }

    public sealed record Success() : TryMarkAsReadResult;

    public sealed record AlreadyWasRead() : TryMarkAsReadResult;

    public sealed record MessageNotFound() : TryMarkAsReadResult;
}