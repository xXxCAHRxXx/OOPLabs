using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ShowCommandModeArgumentFactories;

public interface IShowCommandModeArgumentFactory
{
    IWriter? TryCreate(string mode);
}