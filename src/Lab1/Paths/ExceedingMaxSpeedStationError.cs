using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths;

public record ExceedingMaxSpeedStationError : IBusinessError
{
    public string What => "Exceeding the maximum speed of the station.";
}