using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public interface IArgument<TBuilder>
{
    ArgumentResultType TryApply(TBuilder commandBuilder, IEnumerator<string> iterator);
}