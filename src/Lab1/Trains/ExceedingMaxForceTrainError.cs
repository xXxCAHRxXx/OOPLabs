using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public record ExceedingMaxForceTrainError : IBusinessError
{
    public string What => "Exceeding the maximum force of the train.";
}