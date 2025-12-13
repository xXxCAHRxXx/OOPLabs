using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

public interface ICommandBuilder
{
    CommandBuilderResultType TryBuild();
}