namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public record IsReadResult
{
    private IsReadResult() { }

    public sealed record Read() : IsReadResult;

    public sealed record MessageNotFound() : IsReadResult;

    public sealed record NotRead() : IsReadResult;
}