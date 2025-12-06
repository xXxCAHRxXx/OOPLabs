using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;
using System.Reflection;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ArgumentParserTests
{
    private readonly ISubCommand _argumentParser;

    public ArgumentParserTests()
    {
        _argumentParser = new ArgParserFactory().Create();
    }

    [Fact]
    public void Apply_ParseConnectWithDefaultValue_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("connect somePath");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<ConnectCommand>(success?.Command);

        var command = success.Command as ConnectCommand;
        FieldInfo? address = typeof(ConnectCommand)
            .GetField("_address", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? fileSystem = typeof(ConnectCommand)
            .GetField("_fileSystem", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("somePath", address?.GetValue(command));
        Assert.IsType<LocalFileSystem>(fileSystem?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseConnectWithoutDefaultValue_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("connect somePath -m local");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<ConnectCommand>(success?.Command);

        var command = success.Command as ConnectCommand;
        FieldInfo? address = typeof(ConnectCommand)
            .GetField("_address", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? fileSystem = typeof(ConnectCommand)
            .GetField("_fileSystem", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("somePath", address?.GetValue(command));
        Assert.IsType<LocalFileSystem>(fileSystem?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseDisconnect_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("disconnect");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<DisconnectCommand>(success?.Command);
    }

    [Fact]
    public void Apply_ParseTreeGoTo_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("tree goto somePath");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<GoToCommand>(success?.Command);

        var command = success.Command as GoToCommand;
        FieldInfo? path = typeof(GoToCommand)
            .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("somePath", path?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseTreeList_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("tree list -d 52");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<ListCommand>(success?.Command);

        var command = success.Command as ListCommand;
        FieldInfo? depth = typeof(ListCommand)
            .GetField("_depth", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal(52, depth?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseFileShow_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("file show somePath -m console");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<ShowCommand>(success?.Command);

        var command = success.Command as ShowCommand;
        FieldInfo? path = typeof(ShowCommand)
            .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? writer = typeof(ShowCommand)
            .GetField("_writer", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("somePath", path?.GetValue(command));
        Assert.IsType<ConsoleWriter>(writer?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseFileMove_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("file move someSourcePath someDestinationPath");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<MoveCommand>(success?.Command);

        var command = success.Command as MoveCommand;
        FieldInfo? sourcePath = typeof(MoveCommand)
            .GetField("_sourcePath", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? destinationPath = typeof(MoveCommand)
            .GetField("_destinationPath", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("someSourcePath", sourcePath?.GetValue(command));
        Assert.Equal("someDestinationPath", destinationPath?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseFileCopy_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("file copy someSourcePath someDestinationPath");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<CopyCommand>(success?.Command);

        var command = success.Command as CopyCommand;
        FieldInfo? sourcePath = typeof(CopyCommand)
            .GetField("_sourcePath", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? destinationPath = typeof(CopyCommand)
            .GetField("_destinationPath", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("someSourcePath", sourcePath?.GetValue(command));
        Assert.Equal("someDestinationPath", destinationPath?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseFileDelete_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("file delete somePath");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<DeleteCommand>(success?.Command);

        var command = success.Command as DeleteCommand;
        FieldInfo? sourcePath = typeof(DeleteCommand)
            .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("somePath", sourcePath?.GetValue(command));
    }

    [Fact]
    public void Apply_ParseFileRename_ParseIsSuccess()
    {
        IEnumerator<string> iterator = GetIterator("file rename somePath someName");
        ArgumentParserResultType result = _argumentParser.Apply(iterator);

        Assert.IsType<ArgumentParserResultType.Success>(result);
        var success = result as ArgumentParserResultType.Success;
        Assert.IsType<RenameCommand>(success?.Command);

        var command = success.Command as RenameCommand;
        FieldInfo? path = typeof(RenameCommand)
            .GetField("_path", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? name = typeof(RenameCommand)
            .GetField("_name", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Equal("somePath", path?.GetValue(command));
        Assert.Equal("someName", name?.GetValue(command));
    }

    private IEnumerator<string> GetIterator(string input)
    {
        string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        IEnumerator<string> iterator = ((IEnumerable<string>)tokens).GetEnumerator();
        return iterator;
    }
}