namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component, int depth, int maxDepth);

    void Visit(DirectoryFileSystemComponent component, int depth, int maxDepth);
}