using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public record NoSpeedAndAccelerationError : IBusinessError
{
    public string ErrorMessage => "No speed and acceleration.";
}