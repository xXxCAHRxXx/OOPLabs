namespace Itmo.ObjectOrientedProgramming.Lab2.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}