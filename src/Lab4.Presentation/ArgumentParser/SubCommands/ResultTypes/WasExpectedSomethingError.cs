namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record WasExpectedSomethingError(string Message) : ISubCommandParseError
{
    public string ErrorMessage => Message;
}