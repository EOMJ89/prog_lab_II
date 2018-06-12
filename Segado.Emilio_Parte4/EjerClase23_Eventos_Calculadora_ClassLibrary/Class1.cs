using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase23_Eventos_Calculadora_ClassLibrary
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza una de las cuatro operaciones basicas segun el operador ingresado
        /// </summary>
        /// <param name="numero1"> primer operando clase Numero </param>
        /// <param name="numero2"> segundo operando clase Numero </param>
        /// <param name="operador"> string que determina el operador de la operacion </param>
        /// <returns> double resultado de la operacion entre ambos operandos clase Numero </returns>
        public static double Operar(double numero1, double numero2, int operador)
        {
            double retorno = 0;

            switch (operador)
            {
                case 1:
                    retorno = numero1 + numero2;
                    break;
                case 2:
                    retorno = numero1 - numero2;
                    break;
                case 3:
                    retorno = numero1 * numero2;
                    break;
                case 4:
                    if (numero2 != 0)
                    { retorno = numero1 / numero2; }
                    else
                    { retorno = 0; }
                    break;
                default:
                    break;
            }

            return retorno;
        }
    }
}
