using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public abstract class SubCommandWithBuilderLinkBase<TBuilder> : ISubCommandWithBuilderLink<TBuilder>
where TBuilder : ICommandBuilder, new()
{
    private readonly Dictionary<string, ISubCommand> _childSubCommands = new();
    private readonly List<IPositionalArgument<TBuilder>> _positionalArguments = new();
    private readonly Dictionary<string, IArgumentWithName<TBuilder>> _argumentsWithName = new();

    public abstract string Name { get; }

    public ArgumentParserResultType Apply(IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
            return GetResultFromTryBuild(new TBuilder());

        string currentPhrase = iterator.Current;
        if (_childSubCommands.ContainsKey(currentPhrase))
        {
            ISubCommand child = _childSubCommands[currentPhrase];
            return child.Apply(iterator);
        }

        var commandBuilder = new TBuilder();
        foreach (IPositionalArgument<TBuilder> positionalArgument in _positionalArguments)
        {
            ArgumentResultType result = positionalArgument.TryApply(commandBuilder, iterator);
            if (result is ArgumentResultType.Failure failure)
            {
                return new ArgumentParserResultType.Failure(new ErrorWhileParsingArguments(failure.Error));
            }
            else if (result is ArgumentResultType.EndOfParse endOfParse)
            {
                return GetResultFromTryBuild(commandBuilder);
            }
        }

        while (true)
        {
            currentPhrase = iterator.Current;
            if (_argumentsWithName.ContainsKey(currentPhrase))
            {
                ArgumentResultType result = _argumentsWithName[currentPhrase].TryApply(commandBuilder, iterator);
                if (result is ArgumentResultType.Failure failure)
                {
                    return new ArgumentParserResultType.Failure(new ErrorWhileParsingArguments(failure.Error));
                }
                else if (result is ArgumentResultType.EndOfParse endOfParse)
                {
                    return GetResultFromTryBuild(commandBuilder);
                }
            }
            else
            {
                return new ArgumentParserResultType.Failure(new UnknownCommandError(currentPhrase));
            }
        }
    }

    public ISubCommandWithBuilderLink<TBuilder> AddChildSubCommand(ISubCommand link)
    {
        _childSubCommands[link.Name] = link;
        return this;
    }

    public ISubCommandWithBuilderLink<TBuilder> AddPositionalArgument(IPositionalArgument<TBuilder> positionalArgument)
    {
        _positionalArguments.Add(positionalArgument);
        return this;
    }

    public ISubCommandWithBuilderLink<TBuilder> AddArgumentWithName(IArgumentWithName<TBuilder> argumentWithName)
    {
        _argumentsWithName[argumentWithName.Name] = argumentWithName;
        return this;
    }

    private ArgumentParserResultType GetResultFromTryBuild(TBuilder builder)
    {
        CommandBuilderResultType result = builder.TryBuild();
        if (result is CommandBuilderResultType.Success success)
        {
            return new ArgumentParserResultType.Success(success.Command);
        }

        return new ArgumentParserResultType.Failure(new IncorrectCommandError());
    }
}