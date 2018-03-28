using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Desarrollar una clase llamada Conversor, que posea dos métodos de clase(estáticos):
            //string DecimalBinario(double). Convierte un número de decimal a binario.
            //double BinarioDecimal(string). Convierte un número binario a decimal.
            Console.Title = "Ejercicio Nro 13";
            
            double numero =0;
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
            Console.ReadLine();
        }
    }
}
