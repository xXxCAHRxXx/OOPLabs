namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

public record NotEnoughArgumentsError : ICommandBuilderError
{
    public string ErrorMessage => "Error: Not enough arguments";
}