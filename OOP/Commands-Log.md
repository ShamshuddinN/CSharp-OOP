> This is just to keep track of commands executed, explanation may not be available for every command

## Created a console application
```bash
dotnet new console -n DesignPatterns --use-program-main
```

## Ran the project
```bash
dotnet run --project  DesignPatterns/DesignPatterns.csproj
```

```bash
dotnet new class -n BankAccount
```

```bash
dotnet new class -n EmailService
```
```bash
dotnet new class -n Vehicle
```

```bash
mkdir Inheritance
mv Vehicle.cs ./Inheritance/Vehicle.cs
```

```bash
mkdir Encapsulation
mv BankAccount.cs ./Encapsulation/BankAccount.cs
```

```bash
mkdir Abstraction
mv EmailService.cs ./Abstraction/EmailService.cs
```

```bash
dotnet new class -n Car -o ./Inheritance/
```

```bash
dotnet new class -n Bike -o ./Inheritance/
```

```bash
mkdir Coupling
dotnet new class -n EmailSender -o Coupling/
```

```bash
dotnet new class -n Order -o Coupling/
```

```bash
dotnet new interface -n INotification -o Coupling/
```

```bash
mkdir Composition
dotnet new class -n Car -o Composition/
dotnet new class -n Chassis -o Composition/
dotnet new class -n Engine -o Composition/
dotnet new class -n Seats -o Composition/
dotnet new class -n Wheels -o Composition/
```

video: 1:05:27