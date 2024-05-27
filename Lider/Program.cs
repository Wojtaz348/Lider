

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj rozmiar listy:");
        int rozmiarListy;
        while (!int.TryParse(Console.ReadLine(), out rozmiarListy) || rozmiarListy < 1)
        {
            Console.WriteLine("Nieprawidłowa wartość. Podaj dodatnią liczbę całkowitą:");
        }

        List<int> lista = GenerujListe(rozmiarListy);

        Console.WriteLine("Wygenerowana lista liczb:");
        lista.ForEach(i => Console.Write(i + " "));
        Console.WriteLine();

        var lider = ZnajdzLidera(lista);
        Console.WriteLine($"Czy lista ma lidera? {lider.Item1}, Liczba liderów: {lider.Item2}");
    }

    static List<int> GenerujListe(int rozmiar)
    {
        Random rnd = new Random();
        List<int> wynik = new List<int>();
        for (int i = 0; i < rozmiar; i++)
        {
            wynik.Add(rnd.Next(1, 101)); 
        }
        return wynik;
    }

    static Tuple<bool, int> ZnajdzLidera(List<int> lista)
    {
        Dictionary<int, int> liczbaWystapien = new Dictionary<int, int>();

        foreach (int i in lista)
        {
            if (liczbaWystapien.ContainsKey(i))
            {
                liczbaWystapien[i]++;
            }
            else
            {
                liczbaWystapien.Add(i, 1);
            }
        }

        int maksymalnaLiczbaWystapien = 0;
        foreach (var para in liczbaWystapien)
        {
            if (para.Value > maksymalnaLiczbaWystapien)
            {
                maksymalnaLiczbaWystapien = para.Value;
            }
        }

        bool maLidera = maksymalnaLiczbaWystapien > lista.Count / 2;
        int liczbaLiderow = maLidera ? 1 : 0; 
        return new Tuple<bool, int>(maLidera, liczbaLiderow);
    }
}
