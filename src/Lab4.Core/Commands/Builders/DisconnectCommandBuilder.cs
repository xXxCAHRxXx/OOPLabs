using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public CommandBuilderResultType TryBuild()
    {
        return new CommandBuilderResultType.Success(new DisconnectCommand());
    }
}