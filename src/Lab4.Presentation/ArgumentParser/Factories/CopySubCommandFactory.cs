using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class CopySubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new CopySubCommand()
            .AddPositionalArgument(new CopyCommandSourcePathArgument())
            .AddPositionalArgument(new CopyCommandDestinationPathArgument());
    }
}