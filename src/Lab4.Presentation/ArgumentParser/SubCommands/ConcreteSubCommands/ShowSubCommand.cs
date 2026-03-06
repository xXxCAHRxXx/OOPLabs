using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class ShowSubCommand : SubCommandLinkBase
{
    private readonly IArgument<ShowCommandBuilder> _arguments;

    public ShowSubCommand(IArgument<ShowCommandBuilder> arguments)
    {
        _arguments = arguments;
    }

    public override SubCommandParseResultType Apply(IEnumerator<string> iterator)
    {
        string currentValue = iterator.Current;
        if (currentValue != "show")
            return CallNext(iterator);

        var commandBuilder = new ShowCommandBuilder();
        if (iterator.MoveNext())
        {
            ArgumentResultType resultParsingArguments = _arguments.TryApply(commandBuilder, iterator);
            if (resultParsingArguments is ArgumentResultType.Failure failureArgumentParsing)
            {
                return new SubCommandParseResultType.Failure(
                    new ErrorWhileParsingArguments(failureArgumentParsing.Error));
            }
        }

        return commandBuilder.TryBuild() switch
        {
            CommandBuilderResultType.Failure failure => new SubCommandParseResultType.Failure(new BuilderError(failure.Error)),
            CommandBuilderResultType.Success success => new SubCommandParseResultType.Success(success.Command),
            _ => throw new InvalidOperationException("Error: unexpected result type from TryBuild."),
        };
    }
}