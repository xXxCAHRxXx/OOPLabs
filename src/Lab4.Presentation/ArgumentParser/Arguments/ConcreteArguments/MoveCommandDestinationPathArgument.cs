using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class MoveCommandDestinationPathArgument : ArgumentLinkBase<MoveCommandBuilder>
{
    public override ArgumentResultType TryApply(MoveCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentPath = iterator.Current;
        commandBuilder.WithDestinationPath(currentPath);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return CallNext(commandBuilder, iterator);
    }
}