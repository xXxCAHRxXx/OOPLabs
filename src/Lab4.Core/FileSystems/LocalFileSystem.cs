namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool FileExists(string path) => File.Exists(path);

    public bool DirectoryExists(string path) => Directory.Exists(path);

    public string? GetDirectoryName(string path) => Path.GetDirectoryName(path);

    public string GetFileName(string path) => Path.GetFileName(path);

    public void Copy(string source, string destination) => File.Copy(source, destination, true);

    public void Move(string source, string destination) => File.Move(source, destination, true);

    public void Delete(string path) => File.Delete(path);

    public string ReadAllText(string path) => File.ReadAllText(path);

    public IEnumerable<string> GetEntries(string path)
    {
        foreach (string entry in Directory.EnumerateFileSystemEntries(path))
        {
            yield return entry;
        }
    }

    public bool IsSubDirectory(string directory, string subDirectory)
    {
        return subDirectory.StartsWith(directory + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)
                || string.Equals(directory, subDirectory, StringComparison.OrdinalIgnoreCase);
    }

    public string NormalizePath(string path) => Path.GetFullPath(path)
        .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

    public string Combine(string path1, string path2)
    {
        path1 = NormalizePath(path1);

        path2 = path2.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
            .TrimStart(Path.DirectorySeparatorChar);

        string combined = Path.Combine(path1, path2);
        string fullCombined = NormalizePath(combined);

        return fullCombined;
    }

    public string Combine(string connectionPath, string localPath, string path)
    {
        if (IsAbsolutePath(path))
        {
            return Combine(connectionPath, path);
        }
        else
        {
            return Combine(localPath, path);
        }
    }

    private bool IsAbsolutePath(string path)
    {
        path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
            .TrimStart();

        return path.StartsWith(Path.DirectorySeparatorChar);
    }
}