using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;

public interface ISubCommandFactory
{
    ISubCommand Create();
}