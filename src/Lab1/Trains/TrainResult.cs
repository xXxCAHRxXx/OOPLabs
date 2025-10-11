using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public abstract record TrainResult
{
    private TrainResult() { }

    public sealed record Success(TimeSpan Value) : TrainResult;

    public sealed record Failure(IBusinessError Error) : TrainResult;
}