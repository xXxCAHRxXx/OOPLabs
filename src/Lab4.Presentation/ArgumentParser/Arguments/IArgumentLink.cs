using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public interface IArgumentLink<TBuilder> : IArgument<TBuilder>
where TBuilder : ICommandBuilder
{
    IArgumentLink<TBuilder> AddNext(IArgumentLink<TBuilder> link);
}