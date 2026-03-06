using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers;

public interface IArgParser
{
    ArgParserResultType Apply(IEnumerator<string> iterator);
}