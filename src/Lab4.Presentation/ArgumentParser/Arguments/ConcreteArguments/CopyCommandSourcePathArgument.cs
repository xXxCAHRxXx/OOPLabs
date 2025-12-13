using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class CopyCommandSourcePathArgument : ArgumentLinkBase<CopyCommandBuilder>
{
    public override ArgumentResultType TryApply(CopyCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentPath = iterator.Current;
        commandBuilder.WithSourcePath(currentPath);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return CallNext(commandBuilder, iterator);
    }
}