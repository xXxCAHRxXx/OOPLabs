using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class ConnectCommandAddressArgument : ArgumentLinkBase<ConnectCommandBuilder>
{
    public override ArgumentResultType TryApply(ConnectCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentPath = iterator.Current;
        commandBuilder.WithAddress(currentPath);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return CallNext(commandBuilder, iterator);
    }
}