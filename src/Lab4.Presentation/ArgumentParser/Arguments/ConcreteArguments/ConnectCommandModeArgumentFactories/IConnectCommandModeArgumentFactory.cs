using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ConnectCommandModeArgumentFactories;

public interface IConnectCommandModeArgumentFactory
{
    IFileSystem? TryCreate(string mode);
}