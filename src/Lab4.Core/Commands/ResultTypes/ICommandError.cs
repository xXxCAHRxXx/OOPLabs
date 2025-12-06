namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public interface ICommandError
{
    string ErrorMessage { get; }
}