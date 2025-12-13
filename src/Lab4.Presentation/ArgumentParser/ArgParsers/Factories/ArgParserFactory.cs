using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.SubCommands.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentParser.ArgParsers.Factories;

public class ArgParserFactory : IArgParserFactory
{
    public IArgParser Create()
    {
        return new ArgParser(new ConnectSubCommandFactory().Create()
                    .AddNext(new DisconnectSubCommandFactory().Create())
                    .AddNext(new TreeSubCommandFactory().Create())
                    .AddNext(new FileSubCommandFactory().Create()));
    }
}