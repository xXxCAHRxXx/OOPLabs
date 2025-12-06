namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForShowCommandArgumentMode.IModeFactories;

public sealed class ShowCommandModeArgumentFactory : IShowCommandModeArgumentFactory
{
    public IShowCommandModeArgument Create()
    {
        return new ConsoleShowCommandModeArgumentLink();
    }
}