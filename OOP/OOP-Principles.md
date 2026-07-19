# OOP Principles

- Encapsulation
- Abstraction
- Inheritance
- Polymorphism
- Coupling
- Composition

# Encapsulation:

`Encapsulation is Hiding the internal state and functionality of an object and only allowing access through a public set of functions.`

```C#
# Problem
namespace DesignPatterns;
public class BankAccount
{
    public decimal balance;

}
```

Since balance property is public, anyone using the class can change the value to anything (like a negative value). But in reality balance should not be negative.

In the above case user has to manually handle deposit and withdraw logic for example.

```C#
namespace DesignPatterns;
#Solution

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal balance)
    {
        Deposit(balance);
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive");
        }

        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive");
        }

        if (amount > balance)
        {
            throw new InvalidOperationException("Insufficient balance in account!");
        }

        balance -= amount;
    }


}

```

---

# Abstraction

`Abstraction is Modeling the relevant attributes and interactions of entities as classes to define an abstract representation of a system.`

`Reducing complexity by hiding unnecessary details`

```C#
#Problem

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
```

User has to manually call each individual methods to send an email.
Connect(), Authenticate(), SendEmail() then Disconnect()


```C#
#Solution
namespace DesignPatterns;

public class EmailService
{
    public void SendEmail()
    {
        Connect();
        Authenticate();
        System.Console.WriteLine("Sending Email...");
        Disconnect();
    }

    private void Connect()
    {
        System.Console.WriteLine("Connecting to Email server...");
    }

    private void Authenticate()
    {
        System.Console.WriteLine("Authenticating...");
    }

    private void Disconnect()
    {
        System.Console.WriteLine("Disconnecting from email service");
    }

}
```

Only send email method is exposed to end user. User don't have to worry about other backend functions.

---

# Inheritance

`Inheritance is Ability to create new abstractions based on existing abstractions.`

Inheritance involves creating new classes (subclasses or derived classes) based on existing classes (superclasses or base classes).

Subclasses nherit properties and behaviours from their superclasses and can also add new features or override existing ones.

Inheritance is often described in terms of an "is-a" relationship

```C#
public class Vehicle
{
    public string Brand {get; set;}

    public string Model {get; set;}

    public int Year {get; set;}

    public void Start()
    {
        System.Console.WriteLine("Vehicle is starting...");
    }

    public void Stop()
    {
        System.Console.WriteLine("Vehicle is stopping...");
    }
}

public class Car : Vehicle
{
    public int NumberOfDoors {get; set;}
    public int NumberOfWheels {get; set;}
}

# Bike cannot have Number of Doors
public class Bike : Vehicle
{
    public int NumberOfWheels {get; set;}
}
```

### Avantages
- Don't have to write commonly used fields and methods again for child classes.
- If any changes in Start() method for example, we can do it from a single place.

```C#
        Car car = new();

        // Shared
        car.Brand = "Ford";
        car.Start();
        car.Stop();

        // Unque
        car.NumberOfDoors = 4;
```

---

# Polymorphism

`Polymorphism is Ability to implement inherited properties or methods in different ways across multiple abstractions.`

`Poly : Many`

`Morph: Forms`

`Ability of an object to take many forms`

```C#
public class Vehicle
{
    public string Brand {get; set;}

    public string Model {get; set;}

    public int Year {get; set;}

    //Child classes/Subclasses can override these methods
    public virtual void Start()
    {
        System.Console.WriteLine("Vehicle is starting...");
    }

    public virtual void Stop()
    {
        System.Console.WriteLine("Vehicle is stopping...");
    }

}

public class Bike : Vehicle
{
    public int NumberOfWheels {get; set;}

    // Starting a Bike involves different logic than starting a Car/an Aircraft for example.
    public override void Start()
    {
        System.Console.WriteLine("Bike is starting..");
    }

    public override void Stop()
    {
        System.Console.WriteLine("Bike is stopping..");
    }

}


public class Car : Vehicle
{
    public int NumberOfDoors {get; set;}
    public int NumberOfWheels {get; set;}

    public override void Start()
    {
        System.Console.WriteLine("Car is starting...");
    }

    public override void Stop()
    {
        System.Console.WriteLine("Car is stopping...");
    }

}
```

```C#
//Program.cs
        List<object> vehicles = [];

        vehicles.Add(new Car{Brand = "Ford", Model="Bronco", Year = 2021});
        vehicles.Add( new Bike{Brand = "Honda", Model = "Shine", Year = 2023});

        // Vehicle inspection
        foreach (var vehicle in vehicles)
        {
            if (vehicle is Car)
            {
                // Tyoecasting vehicle to a car
                var car = (Car)vehicle;
                car.Start();
            } else if (vehicle is Bike)
            {
                var bike = (Bike)vehicle;
                bike.Start();
            }
        }
//Problem: If a new vehicle is added, we need to modify this logic
```

Instead:

```C#
//Program.cs
        List<Vehicle> vehicles = [];

        vehicles.Add(new Car{Brand = "Ford", Model="Bronco", Year = 2021});
        vehicles.Add( new Bike{Brand = "Honda", Model = "Shine", Year = 2023});


        // Vehicle inspection
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Stop();
        }
```

---

# Coupling

`The degree of dependency between different classes`

```C#
# Problem
public class EmailSender
{
    public void SendEmail(string message)
    {
        // Email sending logic
        System.Console.WriteLine("Sending Email " + message);
    }
}

public class Order
{
    public void PlaceOrder()
    {
        // Place order logic
        EmailSender emailSender = new();
        emailSender.SendEmail("Order placed successfully");
    }
}
```

- In the above example we could see the order class is tightly coupled to EmailSender class
- Because it directly creates an instance of the EmailSender class
- Which means, Order class depends on implementation details of EmailSender
- Hence Any changes to EmailSender class may also require modifications in Order class


```C#
// Solution
public interface INotificationService
{
    public void SendNotificaton(string message);
}


public class EmailSender : INotificationService
{
    public void SendNotificaton(string message)
    {
        // Email sending logic
        System.Console.WriteLine("Sending Email: " + message);
    }
}

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
```

```C#
//Program.cs
    Order order = new(new EmailSender());
    order.PlaceOrder();
```

Now creating a SMSSender class

```C#
public class SmsSender:INotificationService
{
    public void SendNotificaton(string message)
    {
        System.Console.WriteLine("SMS message: " + message);
    }
}
```

Now if we want to notify user through SMS, then

```C#
//Program.cs
        Order order = new(new SmsSender());
        order.PlaceOrder();
```

Now we have Decoupled the order class from the specific implimentation of the notification service allowing different implementations for example EmailSender or SmsSender to be easily substituted without having to modify the Order class.

This reduces coupling and increases flexibility and maintainability of the codebase.

---

# Composition

`Composition involves creating complex objects by combining simpler objects or components.`

`In composition, objects are assembled together to form larger structures, with each component object maintaining its own state and behavior.`

`Composition is often described in terms of a "has-a" relationship`

```C#
public class Engine
{
    public void Start()
    {
        System.Console.WriteLine("Engine is started");
    }
}

public class Seats
{
    public void Align()
    {
        System.Console.WriteLine("Seats aligned to ideal position");
    }
}

public class Suspension
{
    public void Activate()
    {
        System.Console.WriteLine("Activated suspension");
    }
}

public class Wheels
{
    public void Rotate()
    {
        System.Console.WriteLine("Wheels rotating");
    }
}

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
```

```C#
//Program.cs
    Jeep jeep = new();

    jeep.StartJeep();
```

---

# Composition vs Inheritance

| Composition | Inheritance |
|---|---|
| When you need more flexibility in constructing objects by assembling smaller, reusable components | When there is a clear "is-a" relationship between classes and subclasses, Objects can be treated as instances of their superclasses|
| When there is no clear "is-a" relationship between classes, and "has-a" relationship is more appropriate | When you want to promote code reuse by inheriting properties and behaviors from existing classes |
|When you want to avoid the limitations of inheritance, such as tight coupling and the fragile base class problem| When you want to levarage polymorphism to allow objects of different subclasses to be treated uniformly through their common superclass interface |

---

# Fragile Base Class Problem
- This is a software design issue that arises in object-oriented programming when changes made to a base class can inadverantly break the functionality of derived classes.
- This problem occures due to the tight coupling between base and derived classes in inheritance hierarchies.

1. <strong> Inheritance Coupling: </strong> Inheritance crerates a strong coupling between base class (superclass) and derived classes (subclasses). Any changes made to the base class can potentially affect the behavior of all derived classes.

2. <strong> Limited Extensibility: </strong> The fragile base class problem limits the extensibility of software systems, as modifications to the base class can become incresingly risky and costly over time.

---

## Mitigation Strategies

- To mitigate the Fragile Base Class problem, software developers can use design principles such as Open/Closed Principle (OCP) and Dependency Inversion Principle (DIP), as well as design patterns like Composition over Inheritance.
- These approaches promote loose coupling, encapsulation and modular design redusing the impact of changes in base classes.