using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 05";
            int numero = 0, centro = 0, i = 0;

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

            
            while (i < numero)
            {
                if (i * (1 + i) / 2 == (numero - i - 1) * (i + 2 + numero) / 2)
                {
                    centro = i + 1;
                    
                    break;
                }
                i++;
            }

            if (centro != 0)
            {
                Console.WriteLine("El dentro numero entre {0} y {1} es {2}", 1, numero, centro);
            }
            else
            {
                Console.WriteLine("No hay centro numerico entre {0} y {1}", 1, numero);
            }
            Console.ReadLine();
        }
    }
}
