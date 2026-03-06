using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public string Name { get; }

    private readonly IEnumerable<IAddressee> _addresses;

    public Topic(string name, IEnumerable<IAddressee> addresses)
    {
        Name = name;
        _addresses = addresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee address in _addresses)
        {
            address.Receive(message);
        }
    }
}