using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments;

public abstract class ArgumentLinkBase<TBuilder> : IArgumentLink<TBuilder>
where TBuilder : ICommandBuilder
{
    private IArgumentLink<TBuilder>? _next;

    public abstract ArgumentResultType TryApply(TBuilder commandBuilder, IEnumerator<string> iterator);

    public IArgumentLink<TBuilder> AddNext(IArgumentLink<TBuilder> link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected ArgumentResultType CallNext(TBuilder commandBuilder, IEnumerator<string> iterator)
    {
        return _next?.TryApply(commandBuilder, iterator) ?? new ArgumentResultType.Failure(
            new NoMatchesWereFoundError($"Error: argument {iterator.Current} is undefined."));
    }
}