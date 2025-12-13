namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public record FileNotFoundError(string Message) : ICommandError
{
    public string ErrorMessage => Message;
}