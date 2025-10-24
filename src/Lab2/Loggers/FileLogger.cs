namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message)
    {
        File.AppendAllText(_filePath, $"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
    }
}