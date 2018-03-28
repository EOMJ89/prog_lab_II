using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 02";
            int numero = 0;
            double cuadrado, cubo;

            //Flag
            bool flag = false;

            do
            {
                if (flag == true && numero < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Nro: ");
                numero = int.Parse(Console.ReadLine());

                flag = true;
            } while (numero < 1);

            /* //No Flag
            Console.Write("Ingrese Nro: ");
            numero = int.Parse(Console.ReadLine());

            while (numero <= 0)
            {
                Console.Write("Ingrese Nro: "); 
                Console.WriteLine("ERROR. Reingresar Numero.");
                numero = int.Parse(Console.ReadLine());
            }*/

            cuadrado = Math.Pow(numero, 2);
            cubo = Math.Pow(numero, 3);
            Console.WriteLine("El cuadrado de {0} es: {1:#,#}\nEl cubo de {2} es: {3:#,#}", numero, cuadrado, numero, cubo);
            Console.ReadLine();
        }
    }
}
