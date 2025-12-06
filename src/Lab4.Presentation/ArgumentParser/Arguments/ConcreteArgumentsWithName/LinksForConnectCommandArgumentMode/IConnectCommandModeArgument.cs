using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForConnectCommandArgumentMode;

public interface IConnectCommandModeArgument
{
    IFileSystem? TryApply(string mode);
}