using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class ListSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new ListSubCommand()
            .AddArgumentWithName(new ListCommandDepthArgument());
    }
}