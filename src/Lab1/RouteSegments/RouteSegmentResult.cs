using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public abstract record RouteSegmentResult
{
    private RouteSegmentResult() { }

    public sealed record Success(TimeSpan Value) : RouteSegmentResult;

    public sealed record Failure(IBusinessError Error) : RouteSegmentResult;
}