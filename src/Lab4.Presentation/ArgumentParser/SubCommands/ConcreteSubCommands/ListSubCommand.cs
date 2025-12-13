using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class ListSubCommand : SubCommandLinkBase
{
    private readonly IArgument<ListCommandBuilder> _arguments;

    public ListSubCommand(IArgument<ListCommandBuilder> arguments)
    {
        _arguments = arguments;
    }

    public override SubCommandParseResultType Apply(IEnumerator<string> iterator)
    {
        string currentValue = iterator.Current;
        if (currentValue != "list")
            return CallNext(iterator);

        var commandBuilder = new ListCommandBuilder();
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