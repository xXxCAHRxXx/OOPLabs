namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

public record NoMatchesWereFoundError(string Message) : IArgumentError
{
    public string ErrorMessage => Message;
}