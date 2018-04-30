using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAnimales;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupo veterinario = new Grupo("Río Unica", ETipoManada.Mixta);
            Perro moro = new Perro("Moro", "Pitbull");
            Perro julio = new Perro("Julio", "Cruza",13,false);
            Perro ramon = new Perro("Ramón", "Salchicha", 2,true);
            Gato jose = new Gato("José", "Angora");
            Gato hernan = new Gato("Hernán", "Cruza");
            Gato fer = new Gato("Hernán", "Siames");

            veterinario += moro;
            veterinario += julio;
            veterinario += ramon;
            veterinario += jose;
            veterinario += hernan;
            veterinario += fer;

            Console.WriteLine((string)veterinario);
            Console.ReadLine();
        }
    }
}
