using Itmo.ObjectOrientedProgramming.Lab2.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotification : INotificationSystem
{
    private readonly ConsoleWriter _writer = new();
    private readonly string _message;

    public TextNotification(string message)
    {
        _message = message;
    }

    public void Notify() => _writer.Write($"[NOTIFICATION] {_message}");
}