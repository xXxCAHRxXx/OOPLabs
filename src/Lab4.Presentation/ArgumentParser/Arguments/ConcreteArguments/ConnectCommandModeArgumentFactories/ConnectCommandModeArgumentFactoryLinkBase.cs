using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ConnectCommandModeArgumentFactories;

public abstract class ConnectCommandModeArgumentFactoryLinkBase : IConnectCommandModeArgumentFactoryLink
{
    private IConnectCommandModeArgumentFactoryLink? _next;

    public abstract IFileSystem? TryCreate(string mode);

    public IConnectCommandModeArgumentFactoryLink AddNext(IConnectCommandModeArgumentFactoryLink link)
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

    protected IFileSystem? CallNext(string mode)
    {
        return _next?.TryCreate(mode);
    }
}