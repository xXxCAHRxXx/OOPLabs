namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ShowCommandModeArgumentFactories.ShowCommandModeArgumentFactoryFactories;

public class ShowCommandModeArgumentFactoryFactory : IShowCommandModeArgumentFactoryFactory
{
    public IShowCommandModeArgumentFactory Create()
    {
        return new ConsoleWriterShowCommandModeArgumentFactoryLink();
    }
}