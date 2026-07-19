namespace DesignPatterns;

public class EmailService
{
    
    public void Connect()
    {
        System.Console.WriteLine("Connecting to Email server...");
    }

    public void Authenticate()
    {
        System.Console.WriteLine("Authenticating...");
    }

    public void SendEmail()
    {
        System.Console.WriteLine("Sending Email...");
    }

    public void Disconnect()
    {
        System.Console.WriteLine("Disconnecting from email service");
    }

}
