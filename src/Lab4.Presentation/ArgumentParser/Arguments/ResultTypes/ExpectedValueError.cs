namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

public record ExpectedValueError(string Message) : IArgumentError
{
    public string ErrorMessage => Message;
}