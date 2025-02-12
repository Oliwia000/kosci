using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random random = new Random();
        while (true)
        {
            int iloscKostek = PobierzLiczbeKostek();
            List<int> rzuty = RzucKostkami(iloscKostek, random);
            WyswietlRzuty(rzuty);
            Console.WriteLine($"Liczba uzyskanych punktów: {ObliczPunkty(rzuty)}");

            if (!CzyKontynuowac())
                break;
        }
    }

    static int PobierzLiczbeKostek()
    {
        int ilosc;
        do
        {
            Console.Write("Ile kostek chcesz rzucić? (3 - 10): ");
        } while (!int.TryParse(Console.ReadLine(), out ilosc) || ilosc < 3 || ilosc > 10);
        return ilosc;
    }

    static List<int> RzucKostkami(int ilosc, Random random)
    {
        List<int> rzuty = new List<int>();
        for (int i = 0; i < ilosc; i++)
            rzuty.Add(random.Next(1, 7));
        return rzuty;
    }

    static void WyswietlRzuty(List<int> rzuty)
    {
        for (int i = 0; i < rzuty.Count; i++)
            Console.WriteLine($"Kostka {i + 1}: {rzuty[i]}");
    }

    static int ObliczPunkty(List<int> rzuty)
    {
        return rzuty.GroupBy(x => x)
                    .Where(grupa => grupa.Count() > 1)
                    .Sum(grupa => grupa.Sum());
    }

    static bool CzyKontynuowac()
    {
        Console.Write("Jeszcze raz? (t/n): ");
        return Console.ReadLine().ToLower() == "t";
    }
}
