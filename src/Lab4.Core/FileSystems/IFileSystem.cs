namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    bool FileExists(string path);

    bool DirectoryExists(string path);

    string GetFileName(string path);

    void Copy(string source, string destination);

    void Move(string source, string destination);

    void Delete(string path);

    void Rename(string path, string name);

    string ReadAllText(string path);

    IEnumerable<string> GetEntries(string path);
}