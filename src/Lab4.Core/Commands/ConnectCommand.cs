using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;

    private readonly IFileSystem _fileSystem;

    public ConnectCommand(string address, IFileSystem fileSystem)
    {
        _address = address;
        _fileSystem = fileSystem;
    }

    public CommandResultType Execute(IContext context)
    {
        string normalizedAddress = _fileSystem.NormalizePath(_address);

        if (!_fileSystem.DirectoryExists(normalizedAddress))
        {
            return new CommandResultType.Failure(
                new DirectoryNotFoundError($"Error: directory {normalizedAddress} does not exist."));
        }

        context.Connect(normalizedAddress, _fileSystem);

        return new CommandResultType.Success();
    }
}