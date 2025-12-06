using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    private static void Main(string[] args)
    {
        IFileSystem fileSystem = new LocalFileSystem();
        IPathResolver pathResolver = new UnixPathResolver();
        IFormatter formatter = new Formatter("F: ", "D: ", "    ");
        IWriter writer = new ConsoleWriter();
        IFileSystemComponentVisitor visitor = new FormattingVisitor(formatter, writer);
        IContextFileSystem contextFileSystem = new ContextFileSystem(pathResolver, visitor);

        ISubCommand argumentParser = new ArgParserFactory().Create();

        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                continue;

            if (input == "exit")
                break;

            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IEnumerator<string> iterator = ((IEnumerable<string>)tokens).GetEnumerator();
            ArgumentParserResultType result = argumentParser.Apply(iterator);

            if (result is ArgumentParserResultType.Success success)
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
            else if (result is ArgumentParserResultType.Failure failure)
            {
                Console.WriteLine("failure parsing: " + failure.Error.ErrorMessage);
            }
        }
    }
}