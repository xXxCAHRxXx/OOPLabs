using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class ListSubCommand : SubCommandWithBuilderLinkBase<ListCommandBuilder>
{
    public override string Name { get; } = "list";
}