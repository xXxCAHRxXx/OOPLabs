using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;

public class CopyCommandSourcePathArgument : IPositionalArgument<CopyCommandBuilder>
{
    public ArgumentResultType TryApply(CopyCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        commandBuilder.WithSourcePath(iterator.Current);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}