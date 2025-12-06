namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

public record ExpectedValueError(string ForArgument) : IArgumentError
{
    public string ErrorMessage { get; } = $"Error: expected value for {ForArgument} but nothing was found.";
}