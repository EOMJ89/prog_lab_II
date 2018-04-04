using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro #19";

            Sumador sumador1 = new Sumador(23);
            Sumador sumador2 = new Sumador(3);
            Sumador sumador3 = new Sumador(23);

            Console.WriteLine(sumador1.Sumar(23, 56));
            Console.WriteLine(sumador1.Sumar("23", "56"));
            Console.WriteLine(sumador1);
            Console.WriteLine(sumador1 + sumador2);
            Console.WriteLine(sumador1 | sumador2);
            Console.WriteLine(sumador1 | sumador3);
            Console.ReadLine();

        }
    }
}
