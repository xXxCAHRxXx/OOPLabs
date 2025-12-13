namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public record FileAlreadyExistsError(string Message) : ICommandError
{
    public string ErrorMessage => Message;
}