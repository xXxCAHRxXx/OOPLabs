using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForDeleteSubCommandFactory : IArgumentFactory<DeleteCommandBuilder>
{
    public IArgumentLink<DeleteCommandBuilder> Create()
    {
        return new DeleteCommandPathArgument();
    }
}