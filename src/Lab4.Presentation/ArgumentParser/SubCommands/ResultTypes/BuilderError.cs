using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

public record BuilderError(ICommandBuilderError Error) : ISubCommandParseError
{
    public string ErrorMessage => Error.ErrorMessage;
}