using Itmo.ObjectOrientedProgramming.Lab4.Core.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class ContextFileSystem : IContextFileSystem
{
    private readonly IPathResolver _pathResolver;
    private string _connectionPath;
    private string _localPath;
    private IFileSystem _fileSystem;

    public IFileSystemComponentVisitor Visitor { get; set; }

    public ContextFileSystem(IPathResolver pathResolver, IFileSystemComponentVisitor visitor)
    {
        _connectionPath = string.Empty;
        _localPath = string.Empty;
        _fileSystem = new DisabledFileSystem();
        _pathResolver = pathResolver;
        Visitor = visitor;
    }

    public void Connect(string address, IFileSystem fileSystem)
    {
        _connectionPath = _pathResolver.NormalizePath(address);
        _localPath = _connectionPath;
        _fileSystem = fileSystem;

        if (!_fileSystem.DirectoryExists(_connectionPath))
        {
            Disconnect();
            throw new DirectoryNotFoundException($"Error: directory {_connectionPath} no found.");
        }
    }

    public void Disconnect()
    {
        _connectionPath = string.Empty;
        _localPath = string.Empty;
        _fileSystem = new DisabledFileSystem();
    }

    public void ChangeLocalPath(string path)
    {
        string newLocalPath = GetNormalaizedPath(path);
        bool isSubdirectoryPath = newLocalPath.StartsWith(_connectionPath + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)
                         || string.Equals(newLocalPath, _connectionPath, StringComparison.OrdinalIgnoreCase);

        if (!isSubdirectoryPath)
            throw new InvalidOperationException("Error: you cannot go beyond the connected path.");

        if (!_fileSystem.DirectoryExists(newLocalPath))
            throw new DirectoryNotFoundException($"Error: directory {newLocalPath} no found.");

        _localPath = GetNormalaizedPath(path);
    }

    public void TreeList(int maxDepth)
    {
        var component = new DirectoryFileSystemComponent(_localPath);
        component.Accept(Visitor, 0, maxDepth, _fileSystem);
    }

    public bool FileExists(string path)
    {
        path = GetNormalaizedPath(path);
        return _fileSystem.FileExists(path);
    }

    public bool DirectoryExists(string path)
    {
        path = GetNormalaizedPath(path);
        return _fileSystem.DirectoryExists(path);
    }

    public string GetFileName(string path)
    {
        path = GetNormalaizedPath(path);
        return _fileSystem.GetFileName(path);
    }

    public void Copy(string source, string destination)
    {
        source = GetNormalaizedPath(source);
        destination = GetNormalaizedPath(destination);
        _fileSystem.Copy(source, destination);
    }

    public void Move(string source, string destination)
    {
        source = GetNormalaizedPath(source);
        destination = GetNormalaizedPath(destination);
        _fileSystem.Move(source, destination);
    }

    public void Delete(string path)
    {
        path = GetNormalaizedPath(path);
        _fileSystem.Delete(path);
    }

    public void Rename(string path, string name)
    {
        path = GetNormalaizedPath(path);
        name = GetNormalaizedPath(name);
        _fileSystem.Rename(path, name);
    }

    public string ReadAllText(string path)
    {
        path = GetNormalaizedPath(path);
        return _fileSystem.ReadAllText(path);
    }

    public IEnumerable<string> GetEntries(string path)
    {
        path = GetNormalaizedPath(path);
        return _fileSystem.GetEntries(path);
    }

    private string GetNormalaizedPath(string path)
    {
        string normalizedPath;
        if (_pathResolver.IsAbsolutePath(path))
        {
            normalizedPath = _pathResolver.Combine(_connectionPath, path);
        }
        else
        {
            normalizedPath = _pathResolver.Combine(_localPath, path);
        }

        return normalizedPath;
    }
}