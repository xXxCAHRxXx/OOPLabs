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
        string messageText = $"{message.Head} {message.Body}";

        foreach (string suspiciousWord in _suspiciousWords)
        {
            if (messageText.Contains(suspiciousWord, StringComparison.OrdinalIgnoreCase))
            {
                _notificationSystem.Notify();
                return;
            }
        }
    }
}