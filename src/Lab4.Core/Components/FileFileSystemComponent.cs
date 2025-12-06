using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public class FileFileSystemComponent : IFileSystemComponent
{
    public string Name { get; }

    public FileFileSystemComponent(string name)
    {
        Name = name;
    }

    public void Accept(IFileSystemComponentVisitor visitor, int depth, int maxDepth, IFileSystem fileSystem)
    {
        visitor.Visit(this, depth, maxDepth, fileSystem);
    }
}