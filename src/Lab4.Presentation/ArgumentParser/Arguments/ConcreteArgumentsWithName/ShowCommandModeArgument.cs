using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName;

public class ShowCommandModeArgument : IArgumentWithName<ShowCommandBuilder>
{
    public string Name { get; } = "-m";

    private readonly IShowCommandModeArgument _showCommandArgumentMode;

    public ShowCommandModeArgument(IShowCommandModeArgument showCommandArgumentMode)
    {
        _showCommandArgumentMode = showCommandArgumentMode;
    }

    public ArgumentResultType TryApply(ShowCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
            return new ArgumentResultType.Failure(new ExpectedValueError(Name));

        string currentMode = iterator.Current;
        IWriter? result = _showCommandArgumentMode.TryApply(iterator.Current);
        if (result is null)
            return new ArgumentResultType.Failure(new WrongValueError(currentMode));

        commandBuilder.WithWriter(result);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}