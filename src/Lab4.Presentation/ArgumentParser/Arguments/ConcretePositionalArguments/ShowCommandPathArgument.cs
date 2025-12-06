using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;

public class ShowCommandPathArgument : IPositionalArgument<ShowCommandBuilder>
{
    public ArgumentResultType TryApply(ShowCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        commandBuilder.WithPath(iterator.Current);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}