using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio21Classes;

namespace Ejercicio21_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro #21";

            Fahrenheit euro1 = new Fahrenheit(1);
            Fahrenheit euro2 = new Fahrenheit(2);
            Celsius dolar1 = new Celsius(1);
            Celsius dolar3 = new Celsius(2);
            Kelvin peso1 = new Kelvin(1);
            Kelvin peso2 = new Kelvin(1);

            Console.WriteLine("Mostrar los 1");
            Console.WriteLine("Celsius " + dolar1._temperatura);
            Console.WriteLine("Fahrenheit " + euro1._temperatura);
            Console.WriteLine("Kelvin " + peso1._temperatura);


            //Console.WriteLine("Sumar-Restar Celsius y Fahrenheit");
            //dolar1 += euro1;
            //Console.WriteLine(dolar1._temperatura);
            //dolar1 -= euro1;
            //Console.WriteLine(dolar1._temperatura);

            //Console.WriteLine("\nSumar-Restar Celsius y Kelvin");
            ////Console.WriteLine("1 Kelvin es " + ((Celsius)peso1)._temperatura);
            //dolar1 += peso1;           
            //Console.WriteLine(dolar1._temperatura);
            //dolar1 -= peso1;
            //Console.WriteLine(dolar1._temperatura);

            //Console.WriteLine("\nSumar-Restar Fahrenheit y Celsius");
            ////Console.WriteLine("1 Celsius es {0:#.##}",((Fahrenheit)dolar1)._temperatura);
            //euro1 += dolar1;
            //Console.WriteLine(euro1._temperatura);
            //euro1 -= dolar1;
            //Console.WriteLine(euro1._temperatura);

            //Console.WriteLine("\nSumar-Restar Fahrenheit y Kelvin");
            ////Console.WriteLine("1 Kelvin es " + ((Fahrenheit)peso1)._temperatura);
            //euro1 += peso1;
            //Console.WriteLine(euro1._temperatura);
            //euro1 -= peso1;
            //Console.WriteLine(euro1._temperatura);

            //Console.WriteLine("\nSumar-Restar Kelvin y Fahrenheit");
            //Console.WriteLine("1 Fahrenheit es {0:#.##}",((Kelvin)euro1)._temperatura);
            //peso1 += euro1;
            //Console.WriteLine(peso1._temperatura);
            //peso1 -= euro1;
            //Console.WriteLine(peso1._temperatura);

            //Console.WriteLine("\nSumar-Restar Kelvin y Celcius");
            ////Console.WriteLine("1 Celcius es {0:#.##}", ((Kelvin)dolar1)._temperatura);
            //peso1 += dolar1;
            //Console.WriteLine(peso1._temperatura);
            //peso1 -= dolar1;
            //Console.WriteLine(peso1._temperatura);

            //Console.WriteLine("\nComparar Kelvin a Otros");
            ////Console.WriteLine("1 Kelvin es " + ((Celsius)peso1)._temperatura);
            //Console.WriteLine(peso1 == dolar1);
            ////Console.WriteLine("1 Kelvin es " + ((Fahrenheit)peso1)._temperatura);
            //Console.WriteLine(peso1 == euro1);
            //Console.WriteLine(peso1 == peso2);

            //Console.WriteLine("\nComparar Celsius a Otros");
            //Console.WriteLine(dolar1 == euro1);
            //Console.WriteLine(dolar3 == peso1);

            Console.WriteLine("\nComparar Kelvin a Otros");
            Console.WriteLine(peso1 == dolar1);
            Console.WriteLine(peso1 == euro1);
            Console.WriteLine(peso1 == peso2);
            Console.ReadLine();
        }
    }
}
