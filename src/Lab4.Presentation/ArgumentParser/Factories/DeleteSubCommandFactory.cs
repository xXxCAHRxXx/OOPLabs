using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class DeleteSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new DeleteSubCommand()
            .AddPositionalArgument(new DeleteCommandPathArgument());
    }
}