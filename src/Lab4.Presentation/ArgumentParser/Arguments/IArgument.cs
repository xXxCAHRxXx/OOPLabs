using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public interface IArgument<TBuilder>
where TBuilder : ICommandBuilder
{
    ArgumentResultType TryApply(TBuilder commandBuilder, IEnumerator<string> iterator);
}