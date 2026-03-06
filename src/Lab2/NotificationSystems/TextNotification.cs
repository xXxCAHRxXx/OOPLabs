using Itmo.ObjectOrientedProgramming.Lab2.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotification : INotificationSystem
{
    private readonly IWriter _writer;
    private readonly string _message;

    public TextNotification(IWriter writer, string message)
    {
        _writer = writer;
        _message = message;
    }

    public void Notify() => _writer.Write($"[NOTIFICATION] {_message}");
}