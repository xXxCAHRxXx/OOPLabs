namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public class FormatterPrint : IFormatterPrint
{
    private readonly string _strForFile;
    private readonly string _strForDirectory;
    private readonly string _strForPadding;

    public FormatterPrint(string strForFile, string strForDirectory, string strForPadding)
    {
        _strForFile = strForFile;
        _strForDirectory = strForDirectory;
        _strForPadding = strForPadding;
    }

    public string FormatFile(string name, int depth)
    {
        string padding = string.Concat(Enumerable.Repeat(_strForPadding, depth));
        return padding + _strForFile + name;
    }

    public string FormatDirectory(string name, int depth)
    {
        string padding = string.Concat(Enumerable.Repeat(_strForPadding, depth));
        return padding + _strForDirectory + name;
    }
}