using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.Factories;

public class FileSubCommandFactory : ISubCommandFactory
{
    public ISubCommandLink Create()
    {
        return new FileSubCommand(new ShowSubCommand(new ArgumentsForShowSubCommandFactory().Create())
                         .AddNext(new MoveSubCommand(new ArgumentsForMoveSubCommandFactory().Create()))
                         .AddNext(new CopySubCommand(new ArgumentsForCopySubCommandFactory().Create()))
                         .AddNext(new DeleteSubCommand(new ArgumentsForDeleteSubCommandFactory().Create()))
                         .AddNext(new RenameSubCommand(new ArgumentsForRenameSubCommandFactory().Create())));
    }
}