namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class Context : IContext
{
    public IFileSystem? FileSystem { get; private set; }

    public string ConnectionPath { get; private set; }

    public string LocalPath { get; private set; }

    public Context()
    {
        ConnectionPath = string.Empty;
        LocalPath = string.Empty;
        FileSystem = null;
    }

    public void Connect(string address, IFileSystem fileSystem)
    {
        ConnectionPath = address;
        LocalPath = ConnectionPath;
        FileSystem = fileSystem;
    }

    public void Disconnect()
    {
        ConnectionPath = string.Empty;
        LocalPath = string.Empty;
        FileSystem = null;
    }

    public void ChangeLocalPath(string path)
    {
        LocalPath = path;
    }
}