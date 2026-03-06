using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ConnectCommandModeArgumentFactories;

public class LocalFileSystemConnectCommandModeArgumentFactoryLink : ConnectCommandModeArgumentFactoryLinkBase
{
    public override IFileSystem? TryCreate(string mode)
    {
        if (mode == "local")
            return new LocalFileSystem();

        return CallNext(mode);
    }
}