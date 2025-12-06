namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IContextFileSystem : IFileSystem
{
    void Connect(string address, IFileSystem fileSystem);

    void Disconnect();

    void ChangeLocalPath(string path);

    void TreeList(int maxDepth);
}