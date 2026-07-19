namespace DesignPatterns;

public class EmailSender : INotificationService
{
    public void SendNotificaton(string message)
    {
        // Email sending logic
        System.Console.WriteLine("Sending Email: " + message);
    }
}
