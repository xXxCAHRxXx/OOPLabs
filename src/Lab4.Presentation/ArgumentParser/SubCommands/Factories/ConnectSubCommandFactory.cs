using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.Factories;

public class ConnectSubCommandFactory : ISubCommandFactory
{
    public ISubCommandLink Create()
    {
        return new ConnectSubCommand(new ArgumentsForConnectSubCommandFactory().Create());
    }
}