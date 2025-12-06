using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public interface ICommandBuilder
{
    CommandBuilderResultType TryBuild();
}