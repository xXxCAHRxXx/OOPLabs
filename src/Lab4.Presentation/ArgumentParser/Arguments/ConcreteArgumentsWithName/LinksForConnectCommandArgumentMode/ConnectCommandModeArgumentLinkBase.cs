using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForConnectCommandArgumentMode;

public abstract class ConnectCommandModeArgumentLinkBase : IConnectCommandModeArgumentLink
{
    private IConnectCommandModeArgumentLink? _next;

    public abstract IFileSystem? TryApply(string mode);

    public IConnectCommandModeArgumentLink AddNext(IConnectCommandModeArgumentLink link)
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
        if (_next is null)
            return null;

        return _next.TryApply(mode);
    }
}