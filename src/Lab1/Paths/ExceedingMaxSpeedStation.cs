using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths;

public record ExceedingMaxSpeedStation : IBusinessError
{
    public string What => "Exceeding the maximum speed of the station.";
}