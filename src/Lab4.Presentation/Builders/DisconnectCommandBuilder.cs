using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public CommandBuilderResultType TryBuild()
    {
        return new CommandBuilderResultType.Success(new DisconnectCommand());
    }
}