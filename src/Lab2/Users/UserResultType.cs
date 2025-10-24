namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public record UserResultType
{
    private UserResultType() { }

    public sealed record Success() : UserResultType;

    public sealed record AlreadyWasRead() : UserResultType;

    public sealed record OutOfRangeMessages() : UserResultType;
}