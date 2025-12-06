namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public interface ISubCommandWithoutBuilderLink : ISubCommand
{
    ISubCommandWithoutBuilderLink AddChildSubCommand(ISubCommand link);
}