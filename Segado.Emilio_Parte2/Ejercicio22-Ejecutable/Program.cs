using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio22;

namespace Ejercicio22_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 22";

            double numero = 0;
            Boolean flag = false;
            do
            {
                if (flag == true && numero < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Nro: ");
                numero = double.Parse(Console.ReadLine());

                flag = true;
            } while (numero < 1);

            Console.WriteLine(Conversor.DecimalBinario(numero));

            Console.WriteLine(Conversor.BinarioDecimal(Conversor.DecimalBinario(numero)));

            NumeroBinario A = "1001";
            Console.WriteLine(A._numero);
            NumeroDecimal B = 9;
            Console.WriteLine(B._numero);

            Console.WriteLine((string)A);
            Console.WriteLine((double)B);
            Console.ReadLine();
        }
    }
}
