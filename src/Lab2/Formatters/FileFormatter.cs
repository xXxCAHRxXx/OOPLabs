namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : IFormatter
{
    private readonly string _filePath;

    public FileFormatter(string fileName)
    {
        _filePath = fileName;
    }

    public void WriteHead(string head)
    {
        File.AppendAllText(_filePath, $"# {head}");
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_filePath, body);
    }
}