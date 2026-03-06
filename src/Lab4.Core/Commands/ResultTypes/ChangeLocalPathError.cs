namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public record ChangeLocalPathError(string Message) : ICommandError
{
    public string ErrorMessage => Message;
}