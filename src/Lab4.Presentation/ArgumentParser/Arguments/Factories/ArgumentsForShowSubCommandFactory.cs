using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments.ShowCommandModeArgumentFactories.ShowCommandModeArgumentFactoryFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForShowSubCommandFactory : IArgumentFactory<ShowCommandBuilder>
{
    public IArgumentLink<ShowCommandBuilder> Create()
    {
        return new ShowCommandPathArgument()
            .AddNext(new ShowCommandModeArgument(new ShowCommandModeArgumentFactoryFactory().Create()));
    }
}