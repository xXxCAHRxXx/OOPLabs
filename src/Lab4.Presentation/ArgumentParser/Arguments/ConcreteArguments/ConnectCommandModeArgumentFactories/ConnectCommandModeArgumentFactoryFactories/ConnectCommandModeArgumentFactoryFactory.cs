namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ConnectCommandModeArgumentFactories.ConnectCommandModeArgumentFactoryFactories;

public class ConnectCommandModeArgumentFactoryFactory : IConnectCommandModeArgumentFactoryFactory
{
    public IConnectCommandModeArgumentFactory Create()
    {
        return new LocalFileSystemConnectCommandModeArgumentFactoryLink();
    }
}