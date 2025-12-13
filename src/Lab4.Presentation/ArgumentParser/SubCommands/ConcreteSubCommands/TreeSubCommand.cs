using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class TreeSubCommand : SubCommandLinkBase
{
    private readonly ISubCommand _childSubCommand;

    public TreeSubCommand(ISubCommand childSubCommand)
    {
        _childSubCommand = childSubCommand;
    }

    public override SubCommandParseResultType Apply(IEnumerator<string> iterator)
    {
        string currentValue = iterator.Current;
        if (currentValue != "tree")
            return CallNext(iterator);

        if (iterator.MoveNext())
            return _childSubCommand.Apply(iterator);

        return new SubCommandParseResultType.Failure(
            new WasExpectedSomethingError("Error: after tree was expected something but nothing was found."));
    }
}