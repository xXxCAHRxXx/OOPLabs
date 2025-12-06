using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public class FileSubCommandFactory : ISubCommandFactory
{
    public ISubCommand Create()
    {
        return new FileSubCommand()
            .AddChildSubCommand(new ShowSubCommandFactory().Create())
            .AddChildSubCommand(new MoveSubCommandFactory().Create())
            .AddChildSubCommand(new CopySubCommandFactory().Create())
            .AddChildSubCommand(new DeleteSubCommandFactory().Create())
            .AddChildSubCommand(new RenameSubCommandFactory().Create());
    }
}