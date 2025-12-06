using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode;

public class ConsoleShowCommandModeArgumentLink : ShowCommandModeArgumentLinkBase
{
    private readonly string _mode = "console";

    public override IWriter? TryApply(string mode)
    {
        if (_mode == mode)
            return new ConsoleWriter();

        return CallNext(mode);
    }
}