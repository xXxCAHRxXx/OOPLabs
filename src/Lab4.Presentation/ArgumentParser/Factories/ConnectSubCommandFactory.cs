using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForConnectCommandArgumentMode.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class ConnectSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new ConnectSubCommand()
            .AddPositionalArgument(new ConnectCommandAddressArgument())
            .AddArgumentWithName(new ConnectCommandModeArgument(new ConnectCommandModeArgumentFactory().Create()));
    }
}