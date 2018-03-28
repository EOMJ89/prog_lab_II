using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 03";
            int numero;
            bool flag = false;

            Console.Write("Ingrese Nro: ");
            numero = int.Parse(Console.ReadLine());

            for (int j = 2; j <= numero; j++)
            {
                flag = false;
                for (int i = 1; i <= j; i++)
                {
                    switch (j % i)
                    {
                        case 0:
                            {
                                if (i != 1 && i!=j)
                                {
                                    flag = true;
                                    //Console.WriteLine("{0}%{1} Dio un resto 0 con j&i",j,i);
                                }
                            }
                            break;
                        default:
                            //Dio un resto cualquiera
                            break;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine(j);
                }
            }

            Console.ReadLine();
        }
    }
}
