namespace DesignPatterns;

public class Bike : Vehicle
{
    public int NumberOfWheels {get; set;}

    public override void Start()
    {
        System.Console.WriteLine("Bike is starting..");
    }

    public override void Stop()
    {
        System.Console.WriteLine("Bike is stopping..");
    }

}
