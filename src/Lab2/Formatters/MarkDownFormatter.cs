using Itmo.ObjectOrientedProgramming.Lab2.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkDownFormatter : IFormatter
{
    private readonly IWriter _writer;

    public MarkDownFormatter(IWriter writer)
    {
        _writer = writer;
    }

    public void WriteHead(string head)
    {
        _writer.Write($"# {head}");
    }

    public void WriteBody(string body)
    {
        _writer.Write(body);
    }
}