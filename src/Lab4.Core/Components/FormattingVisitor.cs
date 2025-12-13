using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public class FormattingVisitor : IFileSystemComponentVisitor
{
    private readonly IFileSystem _fileSystem;
    private readonly IWriter _writer;
    private readonly string _strForFile;
    private readonly string _strForDirectory;
    private readonly string _strForPadding;

    public FormattingVisitor(IFileSystem fileSystem, IWriter writer, string strForFile, string strForDirectory, string strForPadding)
    {
        _fileSystem = fileSystem;
        _writer = writer;
        _strForFile = strForFile;
        _strForDirectory = strForDirectory;
        _strForPadding = strForPadding;
    }

    public void Visit(FileFileSystemComponent component, int depth, int maxDepth)
    {
        string fileName = _fileSystem.GetFileName(component.Name);
        _writer.Write(RepeatPadding(depth) + _strForFile + fileName);
    }

    public void Visit(DirectoryFileSystemComponent component, int depth, int maxDepth)
    {
        string directoryName = _fileSystem.GetFileName(component.Name);
        _writer.Write(RepeatPadding(depth) + _strForDirectory + directoryName);

        if (depth >= maxDepth)
            return;

        foreach (IFileSystemComponent comp in component.GetChildren(_fileSystem))
        {
            comp.Accept(this, depth + 1, maxDepth);
        }
    }

    private string RepeatPadding(int depth) => string.Concat(Enumerable.Repeat(_strForPadding, depth));
}