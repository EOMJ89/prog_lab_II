using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometria;

namespace PruebaGeometria
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Ejercicio Nro 18";
            Punto verticeN1 = new Punto(8, 3);
            Punto verticeN3 = new Punto(5, 9);

            Rectangulo rectangulo1 = new Rectangulo(verticeN1, verticeN3);
            rectangulo1.Mostrar();
            Console.WriteLine("El area es {0}.\nEl Perimetro es {1}.", rectangulo1.GetArea(), rectangulo1.GetPerimetro());
            Console.ReadLine();
        }
    }
}
