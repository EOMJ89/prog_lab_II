using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Realizar una clase llamada CalculoDeArea que posea 3 métodos de clase(estáticos) que realicen el cálculo del área que corresponda:
            //a. double CalcularCuadrado(double)
            //b. double CalcularTriangulo(double, double)
            //c. double CalcularCirculo(double)
            //El ingreso de los datos como la visualización se deberán realizar desde el método Main().
            Console.Title = "Ejercicio Nro 14";

            double areaCuadrado = 0, areaTrianguloBase = 0, areaTrianguloAltura = 0, areaCirculo = 0;
            bool flagAreaCuadrado = false, flagAreaTrianguloBase = false, flagAreaTrianguloAltura = false, flagAreaCirculo = false;

            do
            {
                if (flagAreaCuadrado == true && areaCuadrado < 0)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Base/Altura de Cuadrado: ");
                areaCuadrado = float.Parse(Console.ReadLine());
                flagAreaCuadrado = true;
            } while (areaCuadrado < 0);

            Console.WriteLine(CalculoDeArea.CalcularCuadrado(areaCuadrado));
            Console.ReadLine();

            do
            {
                if (flagAreaTrianguloBase == true && areaTrianguloBase < 0)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Base de Triangulo: ");
                areaTrianguloBase = float.Parse(Console.ReadLine());
                flagAreaTrianguloBase = true;
            } while (areaTrianguloBase < 0);

            do
            {
                if (flagAreaTrianguloAltura == true && areaTrianguloAltura < 0)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Altura de Triangulo: ");
                areaTrianguloAltura = float.Parse(Console.ReadLine());
                flagAreaTrianguloAltura = true;
            } while (areaTrianguloAltura < 0);

            Console.WriteLine(CalculoDeArea.CalcularTriangulo(areaTrianguloBase, areaTrianguloAltura));
            Console.ReadLine();

            do
            {
                if (flagAreaCirculo == true && areaCirculo < 0)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Base/Altura de Cuadrado: ");
                areaCirculo = float.Parse(Console.ReadLine());
                flagAreaCirculo = true;
            } while (areaCirculo < 0);

            Console.WriteLine("{0:#.00}", CalculoDeArea.CalcularCirculo(areaCirculo));
            Console.ReadLine();

        }
    }
}
