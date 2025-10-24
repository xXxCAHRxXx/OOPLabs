using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class FilterAddresseeProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevel _minimumImportanceLevel;

    public FilterAddresseeProxy(IAddressee addressee, ImportanceLevel minimumImportanceLevel)
    {
        _addressee = addressee;
        _minimumImportanceLevel = minimumImportanceLevel;
    }

    public void Receive(Message message)
    {
        if (message.ImportanceLevel.CompareTo(_minimumImportanceLevel) >= 0)
            _addressee.Receive(message);
    }
}