using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxKivalasztas
{
    class Program
    {
            struct munkasok
            {
            public string név;
            public int fizetés;

            }
        static void Main(string[] args)
        {
            List<munkasok> munkások = new List<munkasok>();
            StreamReader be = new StreamReader("munkasok.txt");
            be.ReadLine();
            string txt = "munkasok.txt";
            try
            {
                
                var eredmenyek = File.ReadAllLines(txt)
                                     .Select(sor => sor.Split(',')) 
                                     .Select(reszek => new
                                     {
                                         név = reszek[0].Trim(),
                                         fizetés = int.Parse(reszek[1].Trim()) 
                                     })
                                     .ToArray();

                var maxElem = eredmenyek.OrderByDescending(e => e.fizetés).First();

                Console.WriteLine("A legnagyobb értékű személy:");
                Console.WriteLine("Név: " + maxElem.név);
                Console.WriteLine("Fizetés: {0} Ft", maxElem.fizetés);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
            }
            Console.ReadKey();
        }

         
    }
}

