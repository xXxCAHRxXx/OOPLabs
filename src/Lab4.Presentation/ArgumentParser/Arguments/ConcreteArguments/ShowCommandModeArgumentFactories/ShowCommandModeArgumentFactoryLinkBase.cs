using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ShowCommandModeArgumentFactories;

public abstract class ShowCommandModeArgumentFactoryLinkBase : IShowCommandModeArgumentFactoryLink
{
    private IShowCommandModeArgumentFactoryLink? _next;

    public abstract IWriter? TryCreate(string mode);

    public IShowCommandModeArgumentFactoryLink AddNext(IShowCommandModeArgumentFactoryLink link)
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
        return _next?.TryCreate(mode);
    }
}