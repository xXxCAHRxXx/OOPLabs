using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public string Name { get; }

    public DirectoryFileSystemComponent(string name)
    {
        Name = name;
    }

    public IEnumerable<IFileSystemComponent> GetChildren(IFileSystem fileSystem)
    {
        foreach (string entry in fileSystem.GetEntries(Name))
        {
            if (fileSystem.FileExists(entry))
            {
                yield return new FileFileSystemComponent(entry);
            }
            else
            {
                yield return new DirectoryFileSystemComponent(entry);
            }
        }
    }

    public void Accept(IFileSystemComponentVisitor visitor, int depth, int maxDepth, IFileSystem fileSystem)
    {
        visitor.Visit(this, depth, maxDepth, fileSystem);
    }
}