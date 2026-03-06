namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    bool FileExists(string path);

    bool DirectoryExists(string path);

    string GetFileName(string path);

    string? GetDirectoryName(string path);

    void Copy(string source, string destination);

    void Move(string source, string destination);

    void Delete(string path);

    string ReadAllText(string path);

    IEnumerable<string> GetEntries(string path);

    bool IsSubDirectory(string directory, string subDirectory);

    string NormalizePath(string path);

    string Combine(string path1, string path2);

    string Combine(string connectionPath, string localPath, string path);
}