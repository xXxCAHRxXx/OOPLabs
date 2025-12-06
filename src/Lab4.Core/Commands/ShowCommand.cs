using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ShowCommand : BaseCommand
{
    private readonly string _path;
    private readonly IWriter _writer;

    public ShowCommand(string path, IWriter writer)
    {
        _path = path;
        _writer = writer;
    }

    public override CommandResultType Execute(IContextFileSystem contextFileSystem)
    {
        try
        {
            string text = contextFileSystem.ReadAllText(_path);
            _writer.Write(text);
        }
        catch (Exception exception)
        {
            return new CommandResultType.Failure(GetErrorFromException(exception));
        }

        return new CommandResultType.Success();
    }
}