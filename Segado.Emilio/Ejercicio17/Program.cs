using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBoligrafo;

namespace Ejercicio17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 17";
            Boligrafo boliAzul = new Boligrafo(100, ConsoleColor.Blue);
            Boligrafo boliRojo = new Boligrafo(10, ConsoleColor.Red);
            string lineaAzul = "";
            string lineaRoja = "";

            //boliAzul.Pintar(80, out lineaAzul);
            //Console.ReadLine();

            boliRojo.Pintar(15, out lineaRoja);
            Console.ReadLine();

            //boliAzul.Pintar(27, out lineaAzul);
            //Console.ReadLine();
        }
    }
}
