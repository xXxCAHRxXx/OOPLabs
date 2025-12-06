namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers;

public class UnixPathResolver : IPathResolver
{
    public string NormalizePath(string path)
    {
        path = Path.GetFullPath(path);
        return path;
    }

    public string Combine(string path1, string path2)
    {
        path1 = NormalizePath(path1);

        path2 = path2.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
            .TrimStart(Path.DirectorySeparatorChar);

        string combined = Path.Combine(path1, path2);
        string fullCombined = NormalizePath(combined);

        return fullCombined;
    }

    public bool IsAbsolutePath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return false;

        return path.StartsWith('/');
    }
}