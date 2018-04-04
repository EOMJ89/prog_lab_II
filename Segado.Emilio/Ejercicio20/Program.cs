using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro #20";

            Dolar dolar1 = new Dolar(1);
            Euro euro1 = new Euro(1);
            Peso peso1 = new Peso(1);
            /*
            Console.WriteLine(dolar1.GetCantidad());
            Console.WriteLine(euro1.GetCantidad());
            Console.WriteLine(peso1.GetCantidad());
            */

            Console.WriteLine("Sumar-Restar Dolar y Euro");
            dolar1 += euro1;
            Console.WriteLine(dolar1.GetCantidad());
            dolar1 -= euro1;
            Console.WriteLine(dolar1.GetCantidad());

            Console.WriteLine("\nSumar-Restar Dolar y Peso");
            dolar1 += peso1;
            Console.WriteLine(dolar1.GetCantidad());
            dolar1 -= peso1;
            Console.WriteLine(dolar1.GetCantidad());

            Console.WriteLine("\nSumar-Restar Euro y Dolar");
            euro1 += dolar1;
            Console.WriteLine(euro1.GetCantidad());
            euro1 -= dolar1;
            Console.WriteLine(euro1.GetCantidad());

            Console.WriteLine("\nSumar-Restar Euro y Peso");
            euro1 += peso1;
            Console.WriteLine(euro1.GetCantidad());
            euro1 -= peso1;
            Console.WriteLine(euro1.GetCantidad());

            Console.WriteLine("\nSumar-Restar Peso y Euro");
            peso1 += euro1;
            Console.WriteLine(peso1.GetCantidad());
            peso1 -= euro1;
            Console.WriteLine(peso1.GetCantidad());

            Console.WriteLine("\nSumar-Restar Peso y Dolar");
            peso1 += dolar1;
            Console.WriteLine(peso1.GetCantidad());
            peso1 -= dolar1;
            Console.WriteLine(peso1.GetCantidad());
            Console.ReadLine();
        }
    }
}