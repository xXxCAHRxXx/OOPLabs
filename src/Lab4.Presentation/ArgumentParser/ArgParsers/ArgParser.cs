using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers;

public class ArgParser : IArgParser
{
    private readonly ISubCommand _subCommands;

    public ArgParser(ISubCommand subCommands)
    {
        _subCommands = subCommands;
    }

    public ArgParserResultType Apply(IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
        {
            return new ArgParserResultType.Failure(
                new NothingWasGivenError("Error: nothing was given to argument parser."));
        }

        return _subCommands.Apply(iterator) switch
        {
            SubCommandParseResultType.Success success => new ArgParserResultType.Success(success.Command),
            SubCommandParseResultType.Failure failure => new ArgParserResultType.Failure(new ParseError(failure.Error)),
            _ => throw new InvalidOperationException("Error: unexpected result type from apply."),
        };
    }
}