using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Program oblicza średnią ocen ucznia.");

        int liczbaOcen;

        while (true)
        {
            Console.Write("Podaj liczbę ocen do wprowadzenia: ");
            if (int.TryParse(Console.ReadLine(), out liczbaOcen) && liczbaOcen > 0)
                break;

            Console.WriteLine("Niepoprawna liczba. Wprowadź liczbę większą od 0.");
        }

        double suma = 0;
        for (int i = 1; i <= liczbaOcen; i++)
        {
            int ocena;
            while (true)
            {
                Console.Write($"Podaj ocenę {i} (1-6): ");
                if (int.TryParse(Console.ReadLine(), out ocena) && ocena >= 1 && ocena <= 6)
                    break;

                Console.WriteLine("Nieprawidłowa ocena. Wprowadź wartość z przedziału 1–6.");
            }

            suma += ocena;
        }

        double srednia = suma / liczbaOcen;
        Console.WriteLine($"\nŚrednia ocen: {srednia:F2}");

        if (srednia >= 3.0)
            Console.WriteLine("Uczeń zdał.");
        else
            Console.WriteLine("Uczeń nie zdał.");
    }
}