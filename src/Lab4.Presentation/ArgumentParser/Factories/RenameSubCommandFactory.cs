using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class RenameSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new RenameSubCommand()
            .AddPositionalArgument(new RenameCommandPathArgument())
            .AddPositionalArgument(new RenameCommandNameArgument());
    }
}