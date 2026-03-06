namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record NoMatchesWereFoundError(string Message) : ISubCommandParseError
{
    public string ErrorMessage => Message;
}