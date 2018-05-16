using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio26
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Crear una aplicación de consola que cargue 20 números enteros (positivos y negativos) distintos de cero de forma aleatoria utilizando la clase Random.
            a. Mostrar el vector tal como fue ingresado.
            b. Luego mostrar los positivos ordenados en forma decreciente.
            c. Por último, mostrar los negativos ordenados en forma creciente.
            */
            Random r = new Random();
            int[] vectorA = new int[20];

            for (int i = 0; i < vectorA.Length; i++)
            {
                vectorA[i] = r.Next(100, 200);
            }

            Console.WriteLine("\nMostrar como se ingresó");
            for (int i = 0; i < vectorA.Length; i++)
            {
                Console.WriteLine("El numero {0} es {1}.", (i + 1), vectorA[i]);
            }

            Console.WriteLine("\nMostrar de forma decreciente");
            int aux1;

            for (int i = 0; i < vectorA.Length - 1; i++)
            {
                for (int j = i + 1; j < vectorA.Length; j++)
                {
                    if (vectorA[i] < vectorA[j])
                    {
                        aux1 = vectorA[i];
                        vectorA[i] = vectorA[j];
                        vectorA[j] = aux1;
                    }
                }
            }

            for (int i = 0; i < vectorA.Length; i++)
            { Console.WriteLine("El numero {0} es {1}.", (i + 1), vectorA[i]); }

            Console.WriteLine("\nMostrar de forma creciente");
            for (int i = 0; i < vectorA.Length - 1; i++)
            {
                for (int j = i + 1; j < vectorA.Length; j++)
                {
                    if (vectorA[i] > vectorA[j])
                    {
                        aux1 = vectorA[i];
                        vectorA[i] = vectorA[j];
                        vectorA[j] = aux1;
                    }
                }
            }

            for (int i = 0; i < vectorA.Length; i++)
            { Console.WriteLine("El numero {0} es {1}.", (i + 1), vectorA[i]); }

            Console.ReadLine();
        }
    }
}
