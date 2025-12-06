using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class RenameSubCommand : SubCommandWithBuilderLinkBase<RenameCommandBuilder>
{
    public override string Name { get; } = "rename";
}