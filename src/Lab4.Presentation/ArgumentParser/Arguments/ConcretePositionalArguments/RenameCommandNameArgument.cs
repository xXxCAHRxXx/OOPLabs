using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;

public class RenameCommandNameArgument : IPositionalArgument<RenameCommandBuilder>
{
    public ArgumentResultType TryApply(RenameCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        commandBuilder.WithName(iterator.Current);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}