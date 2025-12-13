using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Builders;

public class CopyCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public CopyCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public CopyCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public CommandBuilderResultType TryBuild()
    {
        if (_sourcePath is null || _destinationPath is null)
            return new CommandBuilderResultType.Failure(new NotEnoughArgumentsError());

        return new CommandBuilderResultType.Success(new CopyCommand(_sourcePath, _destinationPath));
    }
}