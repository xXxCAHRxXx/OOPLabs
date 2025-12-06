using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForConnectCommandArgumentMode;

public class LocalFileSystemConnectCommandModeArgumentLink : ConnectCommandModeArgumentLinkBase
{
    private readonly string _mode = "local";

    public override IFileSystem? TryApply(string mode)
    {
        if (_mode == mode)
            return new LocalFileSystem();

        return CallNext(mode);
    }
}