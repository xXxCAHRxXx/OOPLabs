namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers;

public interface IPathResolver
{
    string NormalizePath(string path);

    string Combine(string path1, string path2);

    bool IsAbsolutePath(string path);
}