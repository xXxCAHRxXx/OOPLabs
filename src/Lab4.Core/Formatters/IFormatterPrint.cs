namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public interface IFormatterPrint
{
    string FormatFile(string name, int depth);

    string FormatDirectory(string name, int depth);
}