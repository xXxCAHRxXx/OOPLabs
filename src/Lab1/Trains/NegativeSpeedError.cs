using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public record NegativeSpeedError : IBusinessError
{
    public string What => "Negative speed.";
}