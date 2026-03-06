using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public record ExceedingMaxSpeedStationError : IBusinessError
{
    public string ErrorMessage => "Exceeding the maximum speed of the station.";
}