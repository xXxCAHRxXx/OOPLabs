using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    private readonly IEnumerable<IRouteSegment> _segments;

    private readonly Speed _endMaxSpeed;

    public Route(IEnumerable<IRouteSegment> segments, Speed endMaxSpeed)
    {
        _segments = segments;
        _endMaxSpeed = endMaxSpeed;
    }

    public RouteResult TryTraverse(Train train)
    {
        TimeSpan resultTime = TimeSpan.Zero;
        foreach (IRouteSegment segment in _segments)
        {
            RouteSegmentResult timeCurrentSegment = segment.TrySimulateSegment(train);
            if (timeCurrentSegment is RouteSegmentResult.Success success)
            {
                resultTime += success.Value;
            }
            else if (timeCurrentSegment is RouteSegmentResult.Failure failure)
            {
                return new RouteResult.Failure(failure.Error);
            }
            else
            {
                throw new InvalidOperationException("Unknown result type.");
            }
        }

        if (train.Speed > _endMaxSpeed)
            return new RouteResult.Failure(new ExceedingMaxEndRouteSpeedError());

        return new RouteResult.Success(resultTime);
    }
}