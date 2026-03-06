using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class RenameCommandNameArgument : ArgumentLinkBase<RenameCommandBuilder>
{
    public override ArgumentResultType TryApply(RenameCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentPath = iterator.Current;
        commandBuilder.WithName(currentPath);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return CallNext(commandBuilder, iterator);
    }
}