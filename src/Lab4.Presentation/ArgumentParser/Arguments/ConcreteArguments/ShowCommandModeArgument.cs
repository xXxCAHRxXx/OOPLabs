using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ShowCommandModeArgumentFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class ShowCommandModeArgument : ArgumentLinkBase<ShowCommandBuilder>
{
    private const string Name = "-m";
    private readonly IShowCommandModeArgumentFactory _modeFactory;

    public ShowCommandModeArgument(IShowCommandModeArgumentFactory modeFactory)
    {
        _modeFactory = modeFactory;
    }

    public override ArgumentResultType TryApply(ShowCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        string currentArgument = iterator.Current;
        if (currentArgument == Name)
        {
            ArgumentResultType? result = ParseModeArgument(commandBuilder, iterator);
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
                ArgumentResultType? result = ParseModeArgument(commandBuilder, iterator);
                if (result is not null)
                    return result;
            }
        }
        while (iterator.MoveNext());

        List<string>.Enumerator newIterator = argsWithoutDepthArgument.GetEnumerator();
        newIterator.MoveNext();

        return CallNext(commandBuilder, newIterator);
    }

    private ArgumentResultType? ParseModeArgument(ShowCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
        {
            return new ArgumentResultType.Failure(
                new ExpectedValueError($"Error: after -m argument expected value but nothing was found."));
        }

        string currentValue = iterator.Current;
        IWriter? result = _modeFactory.TryCreate(currentValue);
        if (result is null)
        {
            return new ArgumentResultType.Failure(
                new WrongValueError($"Error: unknown mode {currentValue}."));
        }

        commandBuilder.WithWriter(result);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return null;
    }
}