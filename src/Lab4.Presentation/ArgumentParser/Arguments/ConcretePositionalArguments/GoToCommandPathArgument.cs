using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;

public class GoToCommandPathArgument : IPositionalArgument<GoToCommandBuilder>
{
    public ArgumentResultType TryApply(GoToCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        commandBuilder.WithPath(iterator.Current);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}