namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArgumentsWithName.LinksForConnectCommandArgumentMode.Factories;

public class ConnectCommandModeArgumentFactory : IConnectCommandModeArgumentFactory
{
    public IConnectCommandModeArgument Create()
    {
        return new LocalFileSystemConnectCommandModeArgumentLink();
    }
}