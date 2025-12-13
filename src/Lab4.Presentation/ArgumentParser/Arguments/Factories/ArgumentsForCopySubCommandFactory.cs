using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForCopySubCommandFactory : IArgumentFactory<CopyCommandBuilder>
{
    public IArgumentLink<CopyCommandBuilder> Create()
    {
        return new CopyCommandSourcePathArgument()
            .AddNext(new CopyCommandDestinationPathArgument());
    }
}