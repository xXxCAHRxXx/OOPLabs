using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public record ExceedingMaxEndRouteSpeedError : IBusinessError
{
    public string ErrorMessage => "Exceeding the maximum end route speed.";
}