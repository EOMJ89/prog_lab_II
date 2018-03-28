using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Realizar un programa que sume números enteros hasta que el usuario lo determine, por medio de un mensaje "¿Continuar? (S/N)".
            //En el método estático ValidaS_N(char c) de la clase ValidarRespuesta, se validará el ingreso de opciones.
            //El método devolverá un valor de tipo booleano, TRUE si se ingresó una 'S' y FALSE si se ingresó cualquier otro valor.
            Console.Title = "Ejercicio Nro 12";
            bool continuar = true;
            char respuesta = 'N';
            int numeros = 0, acumulador = 0, contNumeros = 0;

            do
            {
                Console.Write("Ingrese numero {0}: ", contNumeros + 1);
                numeros = int.Parse(Console.ReadLine());
                acumulador += numeros;


                Console.WriteLine("Continuar? S/N");
                respuesta = Console.ReadKey().KeyChar;
                continuar = ValidarRespuesta.ValidaS_N(respuesta);
                Console.WriteLine("");

                contNumeros++;
            } while (continuar != false);

            Console.WriteLine("La suma de los {0} numeros es {1}.", contNumeros, acumulador);
            Console.ReadLine();
        }
    }
}
