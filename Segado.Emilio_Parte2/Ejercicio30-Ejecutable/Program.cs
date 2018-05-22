using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio30_Library;

namespace Ejercicio30_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            AutoF1 a1 = new AutoF1((short)random.Next(1, 99), "Ferrari");
            AutoF1 a2 = new AutoF1((short)random.Next(1, 99), "Chevrolet");
            AutoF1 a3 = new AutoF1((short)random.Next(1, 99), "Honda");
            AutoF1 a4 = new AutoF1((short)random.Next(1, 99), "Subaru");

            Console.WriteLine("Mostrar Datos de los autos:");
            Console.WriteLine(a1.MostrarDatos());
            Console.WriteLine(a2.MostrarDatos());
            Console.WriteLine(a3.MostrarDatos());
            Console.WriteLine(a4.MostrarDatos());

            Competencia competencia1 = new Competencia((short)random.Next(3, 10), 3);
            if (competencia1 + a1)
            { Console.WriteLine("A1 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A1"); }
            if (competencia1 + a1)
            { Console.WriteLine("A1 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A1"); }
            if (competencia1 + a2)
            { Console.WriteLine("A2 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A2"); }
            if (competencia1 + a3)
            { Console.WriteLine("A3 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A3"); }
            if (competencia1 + a4)
            { Console.WriteLine("A4 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A4"); }
            if (competencia1 + a4)
            { Console.WriteLine("A4 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A4"); }

            Console.WriteLine("\nMostrar datos de la competencia:");
            Console.WriteLine(competencia1.MostrarDatos());
            Console.ReadLine();


        }
    }
}
