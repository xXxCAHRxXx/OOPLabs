namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

public interface ICommandBuilderError
{
    string ErrorMessage { get; }
}