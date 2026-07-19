namespace DesignPatterns;

public class Jeep
{
    private Suspension suspension = new();
    private Engine engine = new();
    private Seats seats = new();
    private Wheels wheels = new();

    public void StartJeep()
    {
        engine.Start();
        suspension.Activate();
        seats.Align();
        wheels.Rotate();
        System.Console.WriteLine("Jeep Started");
    }
}
