using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Program pomaga w przeliczeniu temperatury.");

        string choice;
        while (true)
        {
            Console.Write("Jaki chcesz wybrać kierunek konwersji? Do °C czy °F? (Wpisz C lub F): ");
            choice = Console.ReadLine().ToLower();

            if (choice == "c" || choice == "f")
                break;

            Console.WriteLine("Nieprawidłowy wybór. Spróbuj C lub F.");
        }

        int inputTemperature;
        while (true)
        {
            Console.Write("Wprowadź temperaturę: ");
            if (int.TryParse(Console.ReadLine(), out inputTemperature))
                break;

            Console.WriteLine("Nie wprowadzono liczby. Spróbuj ponownie.");
        }

        double converted = ConvertTemperature(inputTemperature, choice);

        if (choice == "f")
        {
            Console.WriteLine($"{inputTemperature}°C = {converted:F2}°F");
        }
        else
        {
            Console.WriteLine($"{inputTemperature}°F = {converted:F2}°C");
        }
    }

    static double ConvertTemperature(int value, string direction)
    {
        if (direction == "f")
            return (value * 1.8) + 32;
        else
            return (value - 32) / 1.8;
    }
}
