using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio36_Library;

namespace Ejercicio36_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            AutoF1 a1 = new AutoF1((short)random.Next(1, 99), "Ferrari", (short)random.Next(1, 150));
            AutoF1 a2 = new AutoF1((short)random.Next(1, 99), "Chevrolet", (short)random.Next(1, 150));
            AutoF1 a3 = new AutoF1((short)random.Next(1, 99), "Honda", (short)random.Next(1, 150));
            AutoF1 a4 = new AutoF1((short)random.Next(1, 99), "Subaru", (short)random.Next(1, 150));

            Console.WriteLine("Mostrar Datos de los autos:");
            Console.WriteLine(a1.MostrarDatos());
            Console.WriteLine(a2.MostrarDatos());
            Console.WriteLine(a3.MostrarDatos());
            Console.WriteLine(a4.MostrarDatos());

            Competencia<AutoF1> competencia1 = new Competencia<AutoF1>((short)random.Next(3, 10), 3, Competencia<AutoF1>.TipoCompetencia.F1);

            MotoCross m1 = new MotoCross((short)random.Next(1, 99), "A", (short)random.Next(1, 150));
            MotoCross m2 = new MotoCross((short)random.Next(1, 99), "B", (short)random.Next(1, 150));
            MotoCross m3 = new MotoCross((short)random.Next(1, 99), "C", (short)random.Next(1, 150));
            MotoCross m4 = new MotoCross((short)random.Next(1, 99), "D", (short)random.Next(1, 150));

            Competencia<MotoCross> competencia2 = new Competencia<MotoCross>((short)random.Next(3, 10), 6, Competencia<MotoCross>.TipoCompetencia.Motos);

            if (competencia1 + a1)
            { Console.WriteLine("A1 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A1"); }
            Console.ReadLine();
            if (competencia1 + a1)
            { Console.WriteLine("A1 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A1"); }
            Console.ReadLine();
            if (competencia1 + a2)
            { Console.WriteLine("A2 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A2"); }
            Console.ReadLine();
            if (competencia1 + a3)
            { Console.WriteLine("A3 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A3"); }
            Console.ReadLine();
            if (competencia1 + a4)
            { Console.WriteLine("A4 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A4"); }
            Console.ReadLine();
            if (competencia1 + a4)
            { Console.WriteLine("A4 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir A4"); }

            Console.WriteLine("\nMostrar datos de la competencia:");
            Console.WriteLine(competencia1.MostrarDatos());
            Console.ReadLine();
            Console.Clear();

            if (competencia2 + m1)
            { Console.WriteLine("M1 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir M1"); }
            Console.ReadLine();
            if (competencia2 + m1)
            { Console.WriteLine("M1 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir M1"); }
            Console.ReadLine();
            if (competencia2 + m2)
            { Console.WriteLine("M2 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir M2"); }
            Console.ReadLine();
            if (competencia2 + m3)
            { Console.WriteLine("M3 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir M3"); }
            Console.ReadLine();
            if (competencia2 + m4)
            { Console.WriteLine("M4 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir M4"); }
            Console.ReadLine();
            if (competencia2 + m4)
            { Console.WriteLine("M4 Añadido Exitosamente"); }
            else
            { Console.WriteLine("Error al añadir M4"); }

            Console.ReadLine();

            //try
            //{
            //    if (competencia2 + a4)
            //    { Console.WriteLine("A4 Añadido Exitosamente"); }
            //    else
            //    { Console.WriteLine("Error al añadir A4"); }
            //}
            //catch (CompetenciaNoDisponibleException e) { Console.WriteLine(e.ToString()); }

            Console.WriteLine("\nMostrar datos de la competencia2:");
            Console.WriteLine(competencia2.MostrarDatos());
            Console.ReadLine();

        }
    }
}
