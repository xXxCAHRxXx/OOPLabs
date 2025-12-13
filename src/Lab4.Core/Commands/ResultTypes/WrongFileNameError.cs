namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public record WrongFileNameError(string Message) : ICommandError
{
    public string ErrorMessage => Message;
}