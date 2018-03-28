using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 01";
            int numeros, acumulador = 0, maximo = 0, minimo = 0;
            float promedio = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Ingrese numero {0}: ", i + 1);
                numeros = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    maximo = numeros;
                    minimo = numeros;
                }
                else
                {
                    if (numeros < minimo)
                    {
                        minimo = numeros;
                    }
                    else if (numeros > maximo)
                    {
                        maximo = numeros;
                    }
                }

                acumulador += numeros;
            }

            promedio = (float)acumulador / 5;
            //Console.WriteLine("El acumulado es: {0}", acumulador);
            Console.WriteLine("El promedio es: {0}\nEl minimo es: {1}\nEl maximo es: {2}", promedio, minimo, maximo);
            Console.ReadLine();
        }
    }
}
