using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 15";
            double primerNumero = 0, segundoNumero = 0, resultado = 0;
            char operacion = ' ', respuesta = ' ';
            Boolean continuar = true;

            do
            {


                Console.Write("Ingrese el 1er Numero: ");
                primerNumero = float.Parse(Console.ReadLine());

                Console.Write("Ingrese el 2do Numero: ");
                segundoNumero = float.Parse(Console.ReadLine());

                Console.Write("Indique la operacion (+,-,*,/): ");
                operacion = Console.ReadKey().KeyChar;

                resultado = Calculadora.Calcular(primerNumero, segundoNumero, operacion);
                Console.WriteLine();
                Calculadora.Mostrar(resultado);

                Console.WriteLine("Continuar? S/N");
                respuesta = Console.ReadKey().KeyChar;
                continuar = Ejercicio12.ValidarRespuesta.ValidaS_N(respuesta);
                Console.WriteLine("");

            } while (continuar != false);
            Console.ReadLine();
        }
    }
}
