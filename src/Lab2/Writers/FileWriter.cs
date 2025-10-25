namespace Itmo.ObjectOrientedProgramming.Lab2.Writers;

public class FileWriter : IWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string message)
    {
        File.AppendAllText(_filePath, message);
    }
}