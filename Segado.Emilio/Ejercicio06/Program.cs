using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 06";
            int anio = 0;

            //Flag
            bool flag = false;

            do
            {
                if (flag == true && anio < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Nro: ");
                anio = int.Parse(Console.ReadLine());
                flag = true;
            } while (anio < 1);

            if (anio % 4 == 0 && anio%100!=0)
            {
                Console.WriteLine("El anio {0} es bisiesto", anio);
            }
            else if (anio % 4 == 0 && anio%100==0 && anio % 400 == 0)
            {
                Console.WriteLine("El anio {0} es bisiesto", anio);
            }
            else
            { Console.WriteLine("El anio {0} no es bisiesto", anio);
            }
            Console.ReadLine();
        }
    }
}
