using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public abstract record ApplyForceResult
{
    private ApplyForceResult() { }

    public sealed record Success() : ApplyForceResult;

    public sealed record Failure(IBusinessError Error) : ApplyForceResult;
}