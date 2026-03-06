using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ConnectCommandModeArgumentFactories.ConnectCommandModeArgumentFactoryFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForConnectSubCommandFactory : IArgumentFactory<ConnectCommandBuilder>
{
    public IArgumentLink<ConnectCommandBuilder> Create()
    {
        return new ConnectCommandAddressArgument()
            .AddNext(new ConnectCommandModeArgument(new ConnectCommandModeArgumentFactoryFactory().Create()));
    }
}