namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public interface ISubCommandLink : ISubCommand
{
    ISubCommandLink AddNext(ISubCommandLink link);
}