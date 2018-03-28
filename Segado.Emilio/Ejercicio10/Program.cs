using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Partiendo de la base del ejercicio anterior, se pide realizar un programa que imprima por pantalla
            //una pirámide como la siguiente:
            //    *
            //   ***
            //  *****
            // *******
            //*********
            //Nota: Utilizar estructuras repetitivas y selectivas
            Console.Title = "Ejercicio Nro 10";
            int cantLineas = 0;
            Boolean flag = false;
            do
            {
                if (flag == true && cantLineas < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Nro: ");
                cantLineas = int.Parse(Console.ReadLine());

                flag = true;
            } while (cantLineas < 1);

            for (int i = 0; i <= cantLineas; i++)
            {
                for (int j = 1; j <= cantLineas-i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}
