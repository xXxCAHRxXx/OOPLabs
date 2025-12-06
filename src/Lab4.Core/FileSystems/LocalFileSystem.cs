namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool FileExists(string path) => File.Exists(path);

    public bool DirectoryExists(string path) => Directory.Exists(path);

    public string GetFileName(string path) => Path.GetFileName(path);

    public void Copy(string source, string destination)
    {
        if (!FileExists(source))
            throw new FileNotFoundException("Error: file not found in Copy", source);

        if (DirectoryExists(destination))
        {
            string fileName = Path.GetFileName(source);
            destination = Path.Combine(destination, fileName);
        }

        File.Copy(source, destination, true);
    }

    public void Move(string source, string destination)
    {
        if (!FileExists(source))
            throw new FileNotFoundException("Error: file not found in Move", source);

        if (DirectoryExists(destination))
        {
            string fileName = Path.GetFileName(source);
            destination = Path.Combine(destination, fileName);
        }

        File.Move(source, destination, true);
    }

    public void Delete(string path)
    {
        if (!FileExists(path))
            throw new FileNotFoundException("Error: file or path not found in Delete", path);

        File.Delete(path);
    }

    public void Rename(string path, string name)
    {
        if (!FileExists(path))
            throw new FileNotFoundException("Error: file not found in Rename", path);

        string directory = Path.GetDirectoryName(path) ?? throw new ArgumentNullException($"Error: wrong directory path : {path}.");
        string newPath = Path.Combine(directory, name);

        if (FileExists(newPath))
            throw new ArgumentException($"Error: file with this name already exists in {directory}.");

        File.Move(path, newPath);
    }

    public string ReadAllText(string path)
    {
        if (!FileExists(path))
            throw new FileNotFoundException("Error: file not found in ReadAllText", path);

        return File.ReadAllText(path);
    }

    public IEnumerable<string> GetEntries(string path)
    {
        if (!DirectoryExists(path))
            throw new DirectoryNotFoundException($"Error: directory {path} no found in GetEntries");

        foreach (string entry in Directory.EnumerateFileSystemEntries(path))
        {
            yield return entry;
        }
    }
}