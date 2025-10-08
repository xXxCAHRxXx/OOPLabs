using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Simulators;

public record ExceedingMaxRouteSpeedError : IBusinessError
{
    public string What => "Exceeding the maximum route speed.";
}