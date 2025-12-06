namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record UnknownCommandError(string CommandName) : IArgumentParserError
{
    public string ErrorMessage { get; } = $"Error: unknown command {CommandName}";
}