using Itmo.ObjectOrientedProgramming.Lab2.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Loggers;

public class Logger : ILogger
{
    private readonly IWriter _writer;

    public Logger(IWriter writer)
    {
        _writer = writer;
    }

    public void Log(string message)
    {
        _writer.Write($"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
    }
}