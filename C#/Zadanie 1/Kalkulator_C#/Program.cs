using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Prosty kalkulator dwóch liczb");

        double number1 = GetNumber("Podaj pierwszą liczbę: ");
        double number2 = GetNumber("Podaj drugą liczbę: ");

        Console.Write("Wybierz operację (+, -, *, /): ");
        string operation = Console.ReadLine();

        double result;
        bool valid = true;

        if (operation == "+")
        {
            result = number1 + number2;
        }
        else if (operation == "-")
        {
            result = number1 - number2;
        }
        else if (operation == "*")
        {
            result = number1 * number2;
        }
        else if (operation == "/")
        {
            if (number2 == 0)
            {
                Console.WriteLine("Nie można dzielić przez zero.");
                valid = false;
                result = 0;
            }
            else
            {
                result = number1 / number2;
            }
        }
        else
        {
            Console.WriteLine("Nieznana operacja.");
            valid = false;
            result = 0;
        }

        if (valid)
        {
            Console.WriteLine($"Wynik: {result}");
        }
    }

    static double GetNumber(string message)
    {
        double number;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out number))
                return number;

            Console.WriteLine("To nie jest poprawna liczba. Spróbuj ponownie.");
        }
    }
}