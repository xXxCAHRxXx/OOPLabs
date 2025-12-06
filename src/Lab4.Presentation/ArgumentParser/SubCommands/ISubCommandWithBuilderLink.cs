using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public interface ISubCommandWithBuilderLink<TBuilder> : ISubCommand
where TBuilder : ICommandBuilder, new()
{
    ISubCommandWithBuilderLink<TBuilder> AddChildSubCommand(ISubCommand link);

    ISubCommandWithBuilderLink<TBuilder> AddPositionalArgument(IPositionalArgument<TBuilder> positionalArgument);

    ISubCommandWithBuilderLink<TBuilder> AddArgumentWithName(IArgumentWithName<TBuilder> argumentWithName);
}