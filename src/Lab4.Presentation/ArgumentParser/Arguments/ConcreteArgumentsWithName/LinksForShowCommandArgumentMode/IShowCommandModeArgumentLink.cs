namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode;

public interface IShowCommandModeArgumentLink : IShowCommandModeArgument
{
    IShowCommandModeArgumentLink AddNext(IShowCommandModeArgumentLink link);
}