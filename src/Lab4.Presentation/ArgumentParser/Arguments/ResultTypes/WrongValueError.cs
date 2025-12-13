namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

public record WrongValueError(string Message) : IArgumentError
{
    public string ErrorMessage => Message;
}