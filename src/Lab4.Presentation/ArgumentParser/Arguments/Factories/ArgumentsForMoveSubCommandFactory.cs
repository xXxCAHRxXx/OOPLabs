using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.ConcreteArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Arguments.Factories;

public class ArgumentsForMoveSubCommandFactory : IArgumentFactory<MoveCommandBuilder>
{
    public IArgumentLink<MoveCommandBuilder> Create()
    {
        return new MoveCommandSourcePathArgument()
            .AddNext(new MoveCommandDestinationPathArgument());
    }
}