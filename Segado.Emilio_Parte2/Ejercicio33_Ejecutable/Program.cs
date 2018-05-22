using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio33_Library;

namespace Ejercicio33_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> paginasRandom = new List<string>();
            paginasRandom.Add("A");
            paginasRandom.Add("B");
            paginasRandom.Add("C");
            paginasRandom.Add("D");
            paginasRandom.Add("E");
            paginasRandom.Add("F");
            paginasRandom.Add("G");
            paginasRandom.Add("H");
            paginasRandom.Add("I");
            paginasRandom.Add("J");
            paginasRandom.Add("K");

            Libro libroA = new Libro(paginasRandom);

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(libroA[i]);
            }
            Console.ReadLine();
            Console.Clear();

            paginasRandom[3] = "Z";

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(libroA[i]);
            }
            Console.ReadLine();
        }
    }
}
