using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosaSpace;

namespace EjerClase04
{
    class Program
    {
        static void Main(string[] args)
        {
            Cosa cosa1 = new Cosa();
            DateTime cumpleaños = new DateTime(1998, 02, 14);
            Cosa cosa2 = new Cosa(14, "Emilio", cumpleaños);
            Cosa cosa3 = new Cosa(20);
            Cosa cosa4 = new Cosa(34, "Cadena");

            Console.WriteLine(cosa1.Mostrar());
            Console.WriteLine("Inicializando...");
            Console.ReadLine();

            //Setters
            cosa1.EstablecerValor(4);
            cosa1.EstablecerValor(DateTime.Now);
            cosa1.EstablecerValor("Prueba");
            Console.WriteLine(cosa1.Mostrar());

            Console.ReadLine();
            //Cosa2
            Console.WriteLine(cosa2.Mostrar());

            Console.ReadLine();
            //Cosa3
            Console.WriteLine(cosa3.Mostrar());

            Console.ReadLine();
            //Cosa4
            Console.WriteLine(cosa4.Mostrar());
            Console.ReadLine();
        }
    }
}
