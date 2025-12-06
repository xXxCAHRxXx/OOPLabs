using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public class FormattingVisitor : IFileSystemComponentVisitor
{
    private readonly IFormatterPrint _formatter;
    private readonly IWriter _writer;

    public FormattingVisitor(IFormatterPrint formatter, IWriter writer)
    {
        _formatter = formatter;
        _writer = writer;
    }

    public void Visit(FileFileSystemComponent component, int depth, int maxDepth, IFileSystem fileSystem)
    {
        string fileName = fileSystem.GetFileName(component.Name);
        _writer.Write(_formatter.FormatFile(fileName, depth));
    }

    public void Visit(DirectoryFileSystemComponent component, int depth, int maxDepth, IFileSystem fileSystem)
    {
        string directoryName = fileSystem.GetFileName(component.Name);
        _writer.Write(_formatter.FormatDirectory(directoryName, depth));

        if (depth >= maxDepth)
            return;

        foreach (IFileSystemComponent comp in component.GetChildren(fileSystem))
        {
            comp.Accept(this, depth + 1, maxDepth, fileSystem);
        }
    }
}