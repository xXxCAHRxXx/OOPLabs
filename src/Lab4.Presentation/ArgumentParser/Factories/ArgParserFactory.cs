using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class ArgParserFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new ArgParser()
            .AddChildSubCommand(new FileSubCommandFactory().Create())
            .AddChildSubCommand(new ConnectSubCommandFactory().Create())
            .AddChildSubCommand(new DisconnectSubCommandFactory().Create())
            .AddChildSubCommand(new TreeSubCommandFactory().Create());
    }
}