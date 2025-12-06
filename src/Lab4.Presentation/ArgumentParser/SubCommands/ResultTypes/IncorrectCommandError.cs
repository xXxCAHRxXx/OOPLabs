namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record IncorrectCommandError : IArgumentParserError
{
    public string ErrorMessage { get; } = "Error: wrong command, expected more arguments.";
}