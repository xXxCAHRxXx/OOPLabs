namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

public record WrongValueError(string Value) : IArgumentError
{
    public string ErrorMessage { get; } = $"Error: cannot parse {Value}, because it is unknown type.";
}