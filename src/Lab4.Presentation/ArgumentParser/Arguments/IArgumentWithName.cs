using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public interface IArgumentWithName<TBuilder> : IArgument<TBuilder>
where TBuilder : ICommandBuilder
{
    string Name { get; }
}