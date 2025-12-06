using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public interface IArgument<TBuilder>
where TBuilder : ICommandBuilder
{
    ArgumentResultType TryApply(TBuilder commandBuilder, IEnumerator<string> iterator);
}