using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public abstract record SubCommandParseResultType
{
    public sealed record Success(ICommand Command) : SubCommandParseResultType;

    public sealed record Failure(ISubCommandParseError Error) : SubCommandParseResultType;
}