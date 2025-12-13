using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.Factories;

public class DisconnectSubCommandFactory : ISubCommandFactory
{
    public ISubCommandLink Create()
    {
        return new DisconnectSubCommand();
    }
}