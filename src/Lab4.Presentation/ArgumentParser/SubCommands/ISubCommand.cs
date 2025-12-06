using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;

public interface ISubCommand
{
    string Name { get; }

    ArgumentParserResultType Apply(IEnumerator<string> iterator);
}