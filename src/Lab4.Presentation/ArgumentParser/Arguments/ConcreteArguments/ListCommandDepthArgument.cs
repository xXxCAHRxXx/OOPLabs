using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class ListCommandDepthArgument : ArgumentLinkBase<ListCommandBuilder>
{
    private const string Name = "-d";

    public override ArgumentResultType TryApply(ListCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentArgument = iterator.Current;
        if (currentArgument == Name)
        {
            ArgumentResultType? result = ParseDepthArgument(commandBuilder, iterator);
            if (result is null)
                return CallNext(commandBuilder, iterator);

            return result;
        }

        var argsWithoutDepthArgument = new List<string>();
        do
        {
            currentArgument = iterator.Current;
            argsWithoutDepthArgument.Add(currentArgument);
            if (currentArgument == Name)
            {
                ArgumentResultType? result = ParseDepthArgument(commandBuilder, iterator);
                if (result is not null)
                    return result;
            }
        }
        while (iterator.MoveNext());

        List<string>.Enumerator newIterator = argsWithoutDepthArgument.GetEnumerator();
        newIterator.MoveNext();

        return CallNext(commandBuilder, newIterator);
    }

    private ArgumentResultType? ParseDepthArgument(ListCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
        {
            return new ArgumentResultType.Failure(
                new ExpectedValueError($"Error: after -m argument expected value but nothing was found."));
        }

        string currentValue = iterator.Current;
        if (int.TryParse(currentValue, out int value))
        {
            if (value < 1)
            {
                return new ArgumentResultType.Failure(
                    new WrongValueError($"Error: value {currentValue} is less than 1."));
            }

            commandBuilder.WithDepth(value);

            if (!iterator.MoveNext())
                return new ArgumentResultType.EndOfParse();

            return null;
        }

        return new ArgumentResultType.Failure(
            new WrongValueError($"Error: value {currentValue} must be int."));
    }
}