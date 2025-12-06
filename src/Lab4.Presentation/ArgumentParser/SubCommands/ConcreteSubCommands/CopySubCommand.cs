using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ConcreteSubCommands;

public class CopySubCommand : SubCommandWithBuilderLinkBase<CopyCommandBuilder>
{
    public override string Name { get; } = "copy";
}