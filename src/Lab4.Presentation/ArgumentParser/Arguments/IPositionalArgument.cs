using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public interface IPositionalArgument<TBuilder> : IArgument<TBuilder>
where TBuilder : ICommandBuilder
{ }