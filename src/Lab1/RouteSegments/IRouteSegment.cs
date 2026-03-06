using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public interface IRouteSegment
{
    RouteSegmentResult TrySimulateSegment(Train train);
}