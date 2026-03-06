using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.ResultTypes;

public abstract record ArgParserResultType
{
    private ArgParserResultType() { }

    public record Success(ICommand Command) : ArgParserResultType;

    public record Failure(IArgParserError Error) : ArgParserResultType;
}