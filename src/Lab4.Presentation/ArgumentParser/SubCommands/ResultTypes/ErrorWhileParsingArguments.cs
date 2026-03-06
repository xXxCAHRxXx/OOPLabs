using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record ErrorWhileParsingArguments(IArgumentError ArgumentError) : ISubCommandParseError
{
    public string ErrorMessage { get; } = ArgumentError.ErrorMessage;
}