using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode.IModeFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcretePositionalArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class ShowSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new ShowSubCommand()
            .AddPositionalArgument(new ShowCommandPathArgument())
            .AddArgumentWithName(new ShowCommandModeArgument(new ShowCommandModeArgumentFactory().Create()));
    }
}