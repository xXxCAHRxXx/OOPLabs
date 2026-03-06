namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

public record NotEnoughArgumentsError : ICommandBuilderError
{
    public string ErrorMessage => "Error: Not enough arguments";
}