using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.Factories;

public class TreeSubCommandFactory : ISubCommandFactory
{
    public ISubCommandLink Create()
    {
        return new TreeSubCommand(new GoToSubCommand(new ArgumentsForGoToSubCommandFactory().Create())
                         .AddNext(new ListSubCommand(new ArgumentsForListSubCommandFactory().Create())));
    }
}