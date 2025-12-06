using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName;

public class ListCommandDepthArgument : IArgumentWithName<ListCommandBuilder>
{
    public string Name { get; } = "-d";

    public ArgumentResultType TryApply(ListCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
            return new ArgumentResultType.Failure(new ExpectedValueError(Name));

        string currentValue = iterator.Current;
        if (int.TryParse(currentValue, out int value))
        {
            if (value < 1)
                return new ArgumentResultType.Failure(new WrongValueError(Name));

            commandBuilder.WithDepth(value);

            if (!iterator.MoveNext())
                return new ArgumentResultType.EndOfParse();

            return new ArgumentResultType.Success();
        }

        return new ArgumentResultType.Failure(new WrongValueError(Name));
    }
}