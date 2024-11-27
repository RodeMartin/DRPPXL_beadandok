using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    class Munkas
    {
        public string Nev { get; set; }
        public int Fizetes { get; set; }
        public string Nem { get; set; }
    }

    static void Main(string[] args)
    {
        // 1. Adatok beolvasása a fájlból
        string filePath = "munkasok.txt";
        List<Munkas> munkasok = new List<Munkas>();

        foreach (var sor in File.ReadAllLines(filePath))
        {
            var adatok = sor.Split(';');
            munkasok.Add(new Munkas
            {
                Nev = adatok[0].Trim(),
                Fizetes = int.Parse(adatok[1].Trim()),
                Nem = adatok[2].Trim().ToLower()
            });
        }

        // 2. Maximumkiválasztás tétele: Legmagasabb fizetésű munkás
        var maxFizetesuMunkas = munkasok.OrderByDescending(m => m.Fizetes).First();
        Console.WriteLine($"Legmagasabb fizetés: {maxFizetesuMunkas.Nev}, {maxFizetesuMunkas.Fizetes} Ft");

        // 3. Kiválogatás tétele: Fizetés > 500000
        var magasFizetesuek = munkasok.Where(m => m.Fizetes > 500000).ToList();
        Console.WriteLine($"\n{magasFizetesuek.Count} dolgozó keres 500.000 Ft felett:");
        
        foreach (var munkas in magasFizetesuek)
        {
            Console.WriteLine($"{munkas.Nev} - {munkas.Fizetes} Ft");
        }

        // 4. Szétválogatás tétele: Nemek szerinti bontás
        var ferfiak = munkasok.Where(m => m.Nem == "férfi").ToList();
        var nok = munkasok.Where(m => m.Nem == "nő").ToList();

        Console.WriteLine($"\nFérfiak száma: {ferfiak.Count}, Nők száma: {nok.Count}");
        Console.WriteLine("\nPéldául: Férfiak:");
        foreach (var ferfi in ferfiak.Take(5)) // Csak 5 példát írunk ki
        {
            Console.WriteLine($"{ferfi.Nev}");
        }

        Console.WriteLine("\nPéldául: Nők:");
        foreach (var no in nok.Take(5)) // Csak 5 példát írunk ki
        {
            Console.WriteLine($"{no.Nev}");
        }
        Console.ReadKey();
    }
}
