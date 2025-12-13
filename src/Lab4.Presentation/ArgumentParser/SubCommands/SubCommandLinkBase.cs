using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public abstract class SubCommandLinkBase : ISubCommandLink
{
    private ISubCommandLink? _next;

    public abstract SubCommandParseResultType Apply(IEnumerator<string> iterator);

    public ISubCommandLink AddNext(ISubCommandLink link)
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

    protected SubCommandParseResultType CallNext(IEnumerator<string> iterator)
    {
        return _next?.Apply(iterator) ?? new SubCommandParseResultType.Failure(
            new NoMatchesWereFoundError($"Error: no matches found with subcommand {iterator.Current}."));
    }
}