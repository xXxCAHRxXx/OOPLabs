using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.ResultTypes;

public record ParseError(ISubCommandParseError Error) : IArgParserError
{
    public string ErrorMessage => Error.ErrorMessage;
}