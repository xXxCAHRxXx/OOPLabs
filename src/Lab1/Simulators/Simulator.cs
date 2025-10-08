using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Simulators;

public class Simulator
{
    private readonly IEnumerable<IRouteSegment> _segments;

    private readonly Speed _endMaxSpeed;

    public Simulator(IEnumerable<IRouteSegment> segments, Speed endMaxSpeed)
    {
        _segments = segments;
        _endMaxSpeed = endMaxSpeed;
    }

    public Result<TimeSpan> TrySimulate(Train train)
    {
        TimeSpan resultTime = TimeSpan.Zero;
        foreach (IRouteSegment segment in _segments)
        {
            Result<TimeSpan> timeCurrentSegment = segment.TrySimulateSegment(train);
            if (timeCurrentSegment.IsFailure)
                return timeCurrentSegment;

            if (timeCurrentSegment is Success<TimeSpan> success)
                resultTime += success.Value;
        }

        if (train.Speed > _endMaxSpeed)
            return Result<TimeSpan>.Fail(new ExceedingMaxRouteSpeedError());

        return Result<TimeSpan>.Success(resultTime);
    }
}