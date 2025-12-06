namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public record DirectoryNotFoundError(string Message) : ICommandError
{
    public string ErrorMessage { get; } = Message;
}