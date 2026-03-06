using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForGoToSubCommandFactory : IArgumentFactory<GoToCommandBuilder>
{
    public IArgumentLink<GoToCommandBuilder> Create()
    {
        return new GoToCommandPathArgument();
    }
}