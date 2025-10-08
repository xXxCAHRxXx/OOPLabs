using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths;

public class Station : IRouteSegment
{
    private readonly Speed _maxAllowedSpeed;

    public Station(Speed maxAllowedSpeed)
    {
        _maxAllowedSpeed = maxAllowedSpeed;
    }

    public Result<TimeSpan> TrySimulateSegment(Train train)
    {
        if (train.Speed > _maxAllowedSpeed)
            return Result<TimeSpan>.Fail(new ExceedingMaxSpeedStation());

        return Result<TimeSpan>.Success(TimeSpan.Zero);
    }
}