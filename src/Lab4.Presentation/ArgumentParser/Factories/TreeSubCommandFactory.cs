using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class TreeSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new TreeSubCommand()
            .AddChildSubCommand(new GoToSubCommandFactory().Create())
            .AddChildSubCommand(new ListSubCommandFactory().Create());
    }
}