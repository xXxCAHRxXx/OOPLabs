namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotification : INotificationSystem
{
    private readonly string _message;

    public TextNotification(string message)
    {
        _message = message;
    }

    public void Notify() => Console.WriteLine($"[NOTIFICATION] {_message}");
}