using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public interface IArgumentFactory<TBuilder>
where TBuilder : ICommandBuilder
{
    IArgumentLink<TBuilder> Create();
}