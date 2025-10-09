using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths;

public class ForceRoute : IRouteSegment
{
    private readonly Force _force;

    private readonly Distance _distance;

    public ForceRoute(Distance distance, Force force)
    {
        if (distance <= Distance.Zero)
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance in path need to be greater than zero");

        _distance = distance;
        _force = force;
    }

    public Result<TimeSpan> TrySimulateSegment(Train train)
    {
        Result<TimeSpan> resultTryApplyForce = train.TryApplyForce(_force);
        if (resultTryApplyForce.IsFailure)
            return resultTryApplyForce;

        Result<TimeSpan> resultTryCalculateDistance = train.TryCalculateDistance(_distance);
        train.ResetAcceleration();
        return resultTryCalculateDistance;
    }
}