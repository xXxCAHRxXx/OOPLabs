using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class ArchiverAddressee : IAddressee
{
    private readonly IArchiver _archiver;

    public ArchiverAddressee(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void Receive(Message message)
    {
        _archiver.Save(message);
    }
}