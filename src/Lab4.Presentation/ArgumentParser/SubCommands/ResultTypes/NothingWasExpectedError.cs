namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record NothingWasExpectedError(string Message) : ISubCommandParseError
{
    public string ErrorMessage => Message;
}