using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    private static void Main(string[] args)
    {
        IContext contextFileSystem = new Context();

        IArgParser argumentParser = new ArgParserFactory().Create();

        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                continue;

            if (input == "exit")
                break;

            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IEnumerator<string> iterator = ((IEnumerable<string>)tokens).GetEnumerator();
            ArgParserResultType result = argumentParser.Apply(iterator);

            if (result is ArgParserResultType.Success success)
            {
                Console.WriteLine("success parsing");
                CommandResultType res = success.Command.Execute(contextFileSystem);
                if (res is CommandResultType.Success sucess2)
                {
                    Console.WriteLine("success command execute");
                }
                else if (res is CommandResultType.Failure failure2)
                {
                    Console.WriteLine("failure command execute " + failure2.Error.ErrorMessage);
                }
            }
            else if (result is ArgParserResultType.Failure failure)
            {
                Console.WriteLine("failure parsing: " + failure.Error.ErrorMessage);
            }
        }
    }
}