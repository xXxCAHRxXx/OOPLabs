using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths;

public interface IRouteSegment
{
    Result<TimeSpan> TrySimulateSegment(Train train);
}