namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class AudioNotification : INotificationSystem
{
    public void Notify()
    {
        Console.Beep();
    }
}