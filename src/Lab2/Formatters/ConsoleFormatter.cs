namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleFormatter : IFormatter
{
    public void WriteHead(string head)
    {
        Console.WriteLine($"# {head}");
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(body);
    }
}