using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;

public class MoveCommandDestinationPathArgument : IPositionalArgument<MoveCommandBuilder>
{
    public ArgumentResultType TryApply(MoveCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        commandBuilder.WithDestinationPath(iterator.Current);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}