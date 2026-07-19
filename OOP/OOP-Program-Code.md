## Encapsulation

```C#
        BankAccount bankAccount = new(500);

        System.Console.WriteLine(bankAccount.GetBalance());

        bankAccount.Deposit(250.58m);

        System.Console.WriteLine(bankAccount.GetBalance());

        bankAccount.Withdraw(120.348m);

        System.Console.WriteLine(bankAccount.GetBalance());

        bankAccount.Withdraw(730.00m);
```

---

## Abstraction

```C#
        EmailService emailService = new();

        emailService.SendEmail();
```

## Inheritance

```C#
        Car car = new();

        // Shared
        car.Brand = "Ford";
        car.Start();
        car.Stop();

        // Unque
        car.NumberOfDoors = 4;
```

