using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForConnectCommandArgumentMode;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName;

public class ConnectCommandModeArgument : IArgumentWithName<ConnectCommandBuilder>
{
    public string Name { get; } = "-m";

    private readonly IConnectCommandModeArgument _connectCommandArgumentMode;

    public ConnectCommandModeArgument(IConnectCommandModeArgument connectCommandArgumentMode)
    {
        _connectCommandArgumentMode = connectCommandArgumentMode;
    }

    public ArgumentResultType TryApply(ConnectCommandBuilder commandBuilder, IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
            return new ArgumentResultType.Failure(new ExpectedValueError(Name));

        string currentMode = iterator.Current;
        IFileSystem? result = _connectCommandArgumentMode.TryApply(currentMode);
        if (result is null)
            return new ArgumentResultType.Failure(new WrongValueError(currentMode));

        commandBuilder.WithFileSystem(result);

        if (!iterator.MoveNext())
            return new ArgumentResultType.EndOfParse();

        return new ArgumentResultType.Success();
    }
}