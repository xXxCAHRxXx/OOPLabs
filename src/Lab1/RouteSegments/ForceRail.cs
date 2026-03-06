using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class ForceRail : IRouteSegment
{
    private readonly Force _force;

    private readonly Distance _distance;

    public ForceRail(Distance distance, Force force)
    {
        _distance = distance;
        _force = force;
    }

    public RouteSegmentResult TrySimulateSegment(Train train)
    {
        ApplyForceResult applyForceResultTry = train.TryApplyForce(_force);
        if (applyForceResultTry is ApplyForceResult.Failure failure)
            return new RouteSegmentResult.Failure(failure.Error);

        TrainResult trainResultTryCalculateDistance = train.TryCalculateDistance(_distance);
        train.TryApplyForce(Force.Zero);

        return trainResultTryCalculateDistance switch
        {
            TrainResult.Success(var value) => new RouteSegmentResult.Success(value),
            TrainResult.Failure(var error) => new RouteSegmentResult.Failure(error),
            _ => throw new InvalidOperationException("Unknown result type."),
        };
    }
}