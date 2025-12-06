using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class DisconnectSubCommand : SubCommandWithBuilderLinkBase<DisconnectCommandBuilder>
{
    public override string Name { get; } = "disconnect";
}