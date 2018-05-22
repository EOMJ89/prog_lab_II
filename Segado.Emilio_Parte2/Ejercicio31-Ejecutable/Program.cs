using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio31_Library;

namespace Ejercicio31_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente clienteA = new Cliente(3, "A");
            Cliente clienteB = new Cliente(2, "B");
            Cliente clienteC = new Cliente(5, "C");
            Cliente clienteD = new Cliente(9, "D");

            Negocio negocioA = new Negocio("El negocio A");

            if (negocioA + clienteA)
            { Console.WriteLine("Cliente A añadido"); }
            else
            { Console.WriteLine("Error al añadir Cliente A"); }

            if (negocioA + clienteB)
            { Console.WriteLine("Cliente B añadido"); }
            else
            { Console.WriteLine("Error al añadir Cliente B"); }

            if (negocioA + clienteC)
            { Console.WriteLine("Cliente C añadido"); }
            else
            { Console.WriteLine("Error al añadir Cliente C"); }

            if (negocioA + clienteD)
            { Console.WriteLine("Cliente D añadido"); }
            else
            { Console.WriteLine("Error al añadir Cliente D"); }

            if (negocioA + clienteA)
            { Console.WriteLine("Cliente A añadido"); }
            else
            { Console.WriteLine("Error al añadir Cliente A"); }

            Console.Clear();
            Console.WriteLine("Atender Cliente A");
            if (~negocioA)
            { Console.WriteLine("Cliente A atendido"); }
            else
            { Console.WriteLine("Error al atender Cliente A"); }

            Console.WriteLine("Atender Cliente B");
            if (~negocioA)
            { Console.WriteLine("Cliente B atendido"); }
            else
            { Console.WriteLine("Error al atender Cliente B"); }

            Console.WriteLine("Atender Cliente C");
            if (~negocioA)
            { Console.WriteLine("Cliente C atendido"); }
            else
            { Console.WriteLine("Error al atender Cliente C"); }

            Console.WriteLine("Atender Cliente D");
            if (~negocioA)
            { Console.WriteLine("Cliente D atendido"); }
            else
            { Console.WriteLine("Error al atender Cliente D"); }

            Console.ReadLine();
        }
    }
}
