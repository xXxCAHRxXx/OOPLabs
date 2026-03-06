using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class DeleteCommandPathArgument : ArgumentLinkBase<DeleteCommandBuilder>
{
    public override ArgumentResultType TryApply(DeleteCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentPath = iterator.Current;
        commandBuilder.WithPath(currentPath);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return CallNext(commandBuilder, iterator);
    }
}