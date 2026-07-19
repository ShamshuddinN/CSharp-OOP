namespace DesignPatterns;

public class SmsSender:INotificationService
{
    public void SendNotificaton(string message)
    {
        System.Console.WriteLine("SMS message: " + message);
    }
}
