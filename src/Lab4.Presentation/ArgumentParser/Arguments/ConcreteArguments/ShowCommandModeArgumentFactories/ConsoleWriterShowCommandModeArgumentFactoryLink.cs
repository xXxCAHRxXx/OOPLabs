using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ShowCommandModeArgumentFactories;

public class ConsoleWriterShowCommandModeArgumentFactoryLink : ShowCommandModeArgumentFactoryLinkBase
{
    public override IWriter? TryCreate(string mode)
    {
        if (mode == "console")
            return new ConsoleWriter();

        return CallNext(mode);
    }
}