using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public class Station : IRouteSegment
{
    private readonly Speed _maxAllowedSpeed;

    public Station(Speed maxAllowedSpeed)
    {
        _maxAllowedSpeed = maxAllowedSpeed;
    }

    public RouteSegmentResult TrySimulateSegment(Train train)
    {
        if (train.Speed > _maxAllowedSpeed)
            return new RouteSegmentResult.Failure(new ExceedingMaxSpeedStationError());

        return new RouteSegmentResult.Success(TimeSpan.Zero);
    }
}