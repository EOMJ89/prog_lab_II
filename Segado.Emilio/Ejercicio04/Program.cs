using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 04";
            int acumuladorDivisores = 0, contador = 0;

            for (int i = 1; i < 999999999; i++)
            {

                    acumuladorDivisores = 0;
                    for (int j
                        = 1; j < i; j++)
                    {
                        switch (i % j)
                        {
                            case 0:
                                {
                                    acumuladorDivisores += j;
                                    //Console.WriteLine(acumuladorDivisores);

                                }
                                break;
                            default:
                                //Dio un resto cualquiera
                                break;
                        }
                        if (i % j == 0)
                        {

                        }
                    }

                    if (acumuladorDivisores == i)
                    {
                        Console.WriteLine("{0} es un numero perfecto.", i);
                        contador++;
                        Console.WriteLine("Contador: {0}", contador);
                    }

                if (contador == 4)
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
