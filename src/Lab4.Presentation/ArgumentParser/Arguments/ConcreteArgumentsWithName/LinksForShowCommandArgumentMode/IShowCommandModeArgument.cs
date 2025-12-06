using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode;

public interface IShowCommandModeArgument
{
    IWriter? TryApply(string mode);
}