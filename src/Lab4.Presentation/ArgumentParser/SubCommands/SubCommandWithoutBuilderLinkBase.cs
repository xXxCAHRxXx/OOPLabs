using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public abstract class SubCommandWithoutBuilderLinkBase : ISubCommandWithoutBuilderLink
{
    private readonly Dictionary<string, ISubCommand> _childSubCommands = new();

    public abstract string Name { get; }

    public ArgumentParserResultType Apply(IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
            return new ArgumentParserResultType.Failure(new IncorrectCommandError());

        string currentPhrase = iterator.Current;
        if (_childSubCommands.ContainsKey(currentPhrase))
        {
            ISubCommand child = _childSubCommands[currentPhrase];
            return child.Apply(iterator);
        }

        return new ArgumentParserResultType.Failure(new UnknownCommandError(currentPhrase));
    }

    public ISubCommandWithoutBuilderLink AddChildSubCommand(ISubCommand link)
    {
        _childSubCommands[link.Name] = link;
        return this;
    }
}