using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Billetes;

namespace Ejercicio20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro #20";

            Euro euro1 = new Euro(1);
            Euro euro2 = new Euro(1);
            Dolar dolar1 = new Dolar(1.3642);
            Dolar dolar2 = new Dolar(1.3642);
            Dolar dolar3 = new Dolar(1);
            Peso peso1 = new Peso(17.55);
            Peso peso2 = new Peso(17.55);
            /*
            Console.WriteLine(dolar1.GetCantidad());
            Console.WriteLine(euro1.GetCantidad());
            Console.WriteLine(peso1.GetCantidad());
            */
            /*
            Console.WriteLine("Sumar-Restar Dolar y Euro");
            dolar1 += euro1;
            Console.WriteLine(dolar1._cantidad);
            dolar1 -= euro1;
            Console.WriteLine(dolar1._cantidad);

            Console.WriteLine("\nSumar-Restar Dolar y Peso");
            dolar1 += peso1;
            Console.WriteLine(dolar1._cantidad);
            dolar1 -= peso1;
            Console.WriteLine(dolar1._cantidad);

            Console.WriteLine("\nSumar-Restar Euro y Dolar");
            euro1 += dolar1;
            Console.WriteLine(euro1._cantidad);
            euro1 -= dolar1;
            Console.WriteLine(euro1._cantidad);

            Console.WriteLine("\nSumar-Restar Euro y Peso");
            euro1 += peso1;
            Console.WriteLine(euro1._cantidad);
            euro1 -= peso1;
            Console.WriteLine(euro1._cantidad);

            Console.WriteLine("\nSumar-Restar Peso y Euro");
            peso1 += euro1;
            Console.WriteLine(peso1._cantidad);
            peso1 -= euro1;
            Console.WriteLine(peso1._cantidad);

            Console.WriteLine("\nSumar-Restar Peso y Dolar");
            peso1 += dolar1;
            Console.WriteLine(peso1._cantidad);
            peso1 -= dolar1;
            Console.WriteLine(peso1._cantidad);*/

            Console.WriteLine("\nComparar Peso a Otros");
            Console.WriteLine(peso1 == dolar3);
            Console.WriteLine(peso1 == euro1);
            Console.WriteLine(peso1 == peso2);

            Console.WriteLine("\nComparar Dolar a Otros");
            Console.WriteLine(dolar1 == dolar2);
            Console.WriteLine(dolar1 == euro1);
            Console.WriteLine(dolar3 == peso2);

            Console.WriteLine("\nComparar Peso a Otros");
            Console.WriteLine(euro1 == dolar1);
            Console.WriteLine(euro1 == euro2);
            Console.WriteLine(euro1 == peso2);
            Console.ReadLine();
        }
    }
}