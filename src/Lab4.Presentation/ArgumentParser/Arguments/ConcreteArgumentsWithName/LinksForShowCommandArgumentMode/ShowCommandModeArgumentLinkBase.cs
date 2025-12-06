using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode;

public abstract class ShowCommandModeArgumentLinkBase : IShowCommandModeArgumentLink
{
    private IShowCommandModeArgumentLink? _next;

    public abstract IWriter? TryApply(string mode);

    public IShowCommandModeArgumentLink AddNext(IShowCommandModeArgumentLink link)
    {
        if (_next == null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected IWriter? CallNext(string mode)
    {
        if (_next is null)
            return null;

        return _next.TryApply(mode);
    }
}