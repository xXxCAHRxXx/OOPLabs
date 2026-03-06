using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class NotificationSystemAddressee : IAddressee
{
    private readonly INotificationSystem _notificationSystem;
    private readonly IEnumerable<string> _suspiciousWords;

    public NotificationSystemAddressee(INotificationSystem system, IEnumerable<string> suspiciousWords)
    {
        _notificationSystem = system;
        _suspiciousWords = suspiciousWords;
    }

    public void Receive(Message message)
    {
        bool hasBanWord =
            _suspiciousWords.Any(word => message.Head.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                                              message.Body.Contains(word, StringComparison.OrdinalIgnoreCase));

        if (hasBanWord)
            _notificationSystem.Notify();
    }
}