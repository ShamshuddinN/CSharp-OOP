namespace DesignPatterns;

public class Order
{
    private readonly INotificationService notificationService;

    public Order(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    public void PlaceOrder()
    {
        // Place order logic
        notificationService.SendNotificaton("Order placed successfully");
    }
}
