using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class DisabledFileSystem : IFileSystem
{
    public bool FileExists(string path) => throw new DisconnectException("Error: you are disconnect.");

    public bool DirectoryExists(string path) => throw new DisconnectException("Error: you are disconnect.");

    public string GetFileName(string path) => throw new DisconnectException("Error: you are disconnect.");

    public void Copy(string source, string destination) => throw new DisconnectException("Error: you are disconnect.");

    public void Move(string source, string destination) => throw new DisconnectException("Error: you are disconnect.");

    public void Delete(string path) => throw new DisconnectException("Error: you are disconnect.");

    public void Rename(string path, string name) => throw new DisconnectException("Error: you are disconnect.");

    public string ReadAllText(string path) => throw new DisconnectException("Error: you are disconnect.");

    public IEnumerable<string> GetEntries(string path) => throw new DisconnectException("Error: you are disconnect.");
}