using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Simulators;

public record ExceedingMaxEndRouteSpeedError : IBusinessError
{
    public string What => "Exceeding the maximum end route speed.";
}