using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record ErrorWhileParsingArguments(IArgumentError ArgumentParserError) : IArgumentParserError
{
    public string ErrorMessage { get; } = ArgumentParserError.ErrorMessage;
}