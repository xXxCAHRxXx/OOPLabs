using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForListSubCommandFactory : IArgumentFactory<ListCommandBuilder>
{
    public IArgumentLink<ListCommandBuilder> Create()
    {
        return new ListCommandDepthArgument();
    }
}