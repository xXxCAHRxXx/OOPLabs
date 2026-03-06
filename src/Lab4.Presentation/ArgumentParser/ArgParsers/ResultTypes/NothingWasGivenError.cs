namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.ResultTypes;

public record NothingWasGivenError(string Message) : IArgParserError
{
    public string ErrorMessage => Message;
}