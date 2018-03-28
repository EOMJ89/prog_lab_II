using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio15
{
    class Calculadora
    {
        public static double Calcular(double pNumero, double sNumero, char cOperacion)
        {
            double retorno = 0;

            switch (cOperacion)
            {
                case '+':
                    {
                        retorno = pNumero + sNumero;
                        break;
                    }
                case '-':
                    {
                        retorno = pNumero - sNumero;
                        break;
                    }
                case '*':
                    {
                        retorno = pNumero * sNumero;
                        break;
                    }
                case '/':
                    {
                        if (Validar(sNumero))
                        {
                            retorno = pNumero / sNumero;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return retorno;
        }

        private static Boolean Validar(double sNumero)
        {
            Boolean retorno = true;

            if (sNumero == 0)
            {
                retorno = false;
            }

            return retorno;
        }

        public static void Mostrar(double resultado)
        {
            Console.WriteLine("El resultado es {0}", resultado);
        }
    }
}
