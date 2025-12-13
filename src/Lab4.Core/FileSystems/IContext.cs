namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IContext
{
    IFileSystem? FileSystem { get; }

    string ConnectionPath { get; }

    string LocalPath { get; }

    void Connect(string address, IFileSystem fileSystem);

    void Disconnect();

    void ChangeLocalPath(string path);
}