using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IEnumerable<IAddressee> _addresses;

    public GroupAddressee(IEnumerable<IAddressee> addresses)
    {
        _addresses = addresses;
    }

    public void Receive(Message message)
    {
        foreach (IAddressee addressee in _addresses)
        {
            addressee.Receive(message);
        }
    }
}