using System;
using System.Threading;

// The Pet class represents a virtual pet with various attributes and actions.
class Pet
{
    // Properties to store pet details and stats.
    public string Type { get; set; }
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }

    // Constructor to initialize a new Pet instance with default values.
    public Pet(string type, string name)
    {
        Type = type;
        Name = name;
        Hunger = 5;
        Happiness = 5;
        Health = 5;
    }

    // Display the current status of the pet.
    public void DisplayStatus()
    {
        Console.WriteLine($"Pet Type: {Type}");
        Console.WriteLine($"Pet Name: {Name}");
        Console.WriteLine($"Hunger: {Hunger}/10");
        Console.WriteLine($"Happiness: {Happiness}/10");
        Console.WriteLine($"Health: {Health}/10");
        Console.WriteLine();
    }

    // Action: Feed the pet, decreasing hunger and slightly increasing health.
    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} has been fed. Hunger decreased, health increased.");
        Console.WriteLine();
    }

    // Action: Play with the pet, increasing happiness and hunger slightly.
    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"{Name} enjoyed playing. Happiness increased, hunger increased slightly.");
        Console.WriteLine();
    }

    // Action: Rest the pet, increasing health and decreasing happiness slightly.
    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"{Name} is resting. Health increased, happiness decreased slightly.");
        Console.WriteLine();
    }

    // Check and display the pet's current health.
    public void CheckHealth()
    {
        Console.WriteLine($"{Name}'s current health is {Health}/10.");
        Console.WriteLine();
    }

    // Simulate the passage of time, updating hunger, happiness, and health.
    public void TimePasses()
    {
        Hunger += 1;
        Happiness -= 1;

        // Check for critical hunger and decrease health.
        if (Hunger >= 8)
        {
            Health -= 1;
            Console.WriteLine($"{Name} is getting hungry. Health slightly decreased.");
        }

        // Check for critical happiness and decrease health.
        if (Happiness <= 2)
        {
            Health -= 1;
            Console.WriteLine($"{Name} is unhappy. Health slightly decreased.");
        }

        Console.WriteLine();
    }

    // Check and display warnings if any of the pet's stats are critically low.
    public void CheckStatus()
    {
        if (Hunger <= 2)
            Console.WriteLine($"Warning: {Name}'s hunger is critically low!");

        if (Happiness <= 2)
            Console.WriteLine($"Warning: {Name}'s happiness is critically low!");

        if (Health <= 2)
            Console.WriteLine($"Warning: {Name}'s health is critically low!");

        Console.WriteLine();
    }
}

// The Program class contains the main method to execute the virtual pet simulator.
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulator!");

        // Display options for choosing the pet type.
        Console.WriteLine("Choose pet type:");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");

        // Prompt the user to enter the number corresponding to their pet type choice.
        Console.Write("Enter the number corresponding to your choice: ");
        string petTypeChoice = Console.ReadLine();

        string petType;

        // Map the user's choice to the pet type.
        switch (petTypeChoice)
        {
            case "1":
                petType = "Cat";
                break;
            case "2":
                petType = "Dog";
                break;
            case "3":
                petType = "Rabbit";
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to Cat.");
                petType = "Cat";
                break;
        }

        // Prompt the user to enter the pet name.
        Console.Write("Enter pet name: ");
        string petName = Console.ReadLine();

        // Create a new Pet instance with the specified type and name.
        Pet pet = new Pet(petType, petName);

        // Display a welcome message for the pet.
        Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

        // Main loop for interacting with the virtual pet.
        while (true)
        {
            // Display the current status of the pet.
            pet.DisplayStatus();

            // Display options for actions the user can take.
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Feed the pet");
            Console.WriteLine("2. Play with the pet");
            Console.WriteLine("3. Rest the pet");
            Console.WriteLine("4. Check health");
            Console.WriteLine("5. Quit");

            // Prompt the user to enter their choice.
            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            // Perform the corresponding action based on the user's choice.
            switch (choice)
            {
                case "1":
                    pet.Feed();
                    break;
                case "2":
                    pet.Play();
                    break;
                case "3":
                    pet.Rest();
                    break;
                case "4":
                    pet.CheckHealth();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            // Simulate the passage of time and update the pet's status.
            pet.TimePasses();

            // Check and display warnings about the pet's status.
            pet.CheckStatus();

            // Pause for a moment to make the changes visible.
            Thread.Sleep(1000);


        }
    }
}
