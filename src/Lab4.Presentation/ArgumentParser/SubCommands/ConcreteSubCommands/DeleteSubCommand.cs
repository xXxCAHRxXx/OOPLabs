using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class DeleteSubCommand : SubCommandWithBuilderLinkBase<DeleteCommandBuilder>
{
    public override string Name { get; } = "delete";
}