using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForRenameSubCommandFactory : IArgumentFactory<RenameCommandBuilder>
{
    public IArgumentLink<RenameCommandBuilder> Create()
    {
        return new RenameCommandPathArgument()
            .AddNext(new RenameCommandNameArgument());
    }
}