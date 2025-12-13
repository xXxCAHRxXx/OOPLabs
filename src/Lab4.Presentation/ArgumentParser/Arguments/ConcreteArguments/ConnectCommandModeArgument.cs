using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ConnectCommandModeArgumentFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;

public class ConnectCommandModeArgument : ArgumentLinkBase<ConnectCommandBuilder>
{
    private const string Name = "-m";
    private readonly IConnectCommandModeArgumentFactory _modeFactory;

    public ConnectCommandModeArgument(IConnectCommandModeArgumentFactory modeFactory)
    {
        _modeFactory = modeFactory;
    }

    public override ArgumentResultType TryApply(ConnectCommandBuilder commandBuilder, IEnumerator<string> iterator)
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

    private ArgumentResultType? ParseModeArgument(ConnectCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
        {
            return new ArgumentResultType.Failure(
                new ExpectedValueError($"Error: after -m argument expected value but nothing was found."));
        }

        string currentValue = iterator.Current;
        IFileSystem? result = _modeFactory.TryCreate(currentValue);
        if (result is null)
        {
            return new ArgumentResultType.Failure(
                new WrongValueError($"Error: unknown mode {currentValue}."));
        }

        commandBuilder.WithFileSystem(result);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return null;
    }
}