namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor, int depth, int maxDepth);
}