using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;

public class ConnectCommandAddressArgument : IPositionalArgument<ConnectCommandBuilder>
{
    public ArgumentResultType TryApply(ConnectCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        commandBuilder.WithAddress(iterator.Current);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}