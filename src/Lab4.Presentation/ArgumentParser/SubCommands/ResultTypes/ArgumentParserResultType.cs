using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public abstract record ArgumentParserResultType
{
    public sealed record Success(ICommand Command) : ArgumentParserResultType;

    public sealed record Failure(IArgumentParserError Error) : ArgumentParserResultType;
}