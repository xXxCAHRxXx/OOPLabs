namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public interface IFormatter
{
    string FormatFile(string name, int depth);

    string FormatDirectory(string name, int depth);
}