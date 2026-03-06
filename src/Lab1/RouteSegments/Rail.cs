using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class Rail : IRouteSegment
{
    private readonly Distance _distance;

    public Rail(Distance distance)
    {
        _distance = distance;
    }

    public RouteSegmentResult TrySimulateSegment(Train train)
    {
        TrainResult trainResultRouteSegment = train.TryCalculateDistance(_distance);

        return trainResultRouteSegment switch
        {
            TrainResult.Success(var value) => new RouteSegmentResult.Success(value),
            TrainResult.Failure(var error) => new RouteSegmentResult.Failure(error),
            _ => throw new InvalidOperationException("Unknown result type."),
        };
    }
}