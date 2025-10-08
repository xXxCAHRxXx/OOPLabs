using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths;

public class Path : IRouteSegment
{
    private readonly Distance _distance;

    public Path(Distance distance)
    {
        if (distance <= Distance.Zero)
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance in path need to be greater than zero");

        _distance = distance;
    }

    public Result<TimeSpan> TrySimulateSegment(Train train)
    {
        return train.TryCalculateDistance(_distance);
    }
}