using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class DisconnectSubCommand : SubCommandLinkBase
{
    public override SubCommandParseResultType Apply(IEnumerator<string> iterator)
    {
        string currentValue = iterator.Current;
        if (currentValue != "disconnect")
            return CallNext(iterator);

        var commandBuilder = new DisconnectCommandBuilder();
        if (iterator.MoveNext())
        {
            return new SubCommandParseResultType.Failure(
                new NothingWasExpectedError($"Error: nothing was expected but was found {iterator.Current}."));
        }

        return commandBuilder.TryBuild() switch
        {
            CommandBuilderResultType.Failure failure => new SubCommandParseResultType.Failure(new BuilderError(failure.Error)),
            CommandBuilderResultType.Success success => new SubCommandParseResultType.Success(success.Command),
            _ => throw new InvalidOperationException("Error: unexpected result type from TryBuild."),
        };
    }
}