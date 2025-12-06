using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component, int depth, int maxDepth, IFileSystem fileSystem);

    void Visit(DirectoryFileSystemComponent component, int depth, int maxDepth, IFileSystem fileSystem);
}