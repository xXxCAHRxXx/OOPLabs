using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record Success(TimeSpan Value) : RouteResult;

    public sealed record Failure(IBusinessError Error) : RouteResult;
}
