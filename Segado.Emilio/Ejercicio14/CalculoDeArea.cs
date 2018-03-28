using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio14
{
    class CalculoDeArea
    {
        public static double CalcularCuadrado (double baseCuadrado)
        {
            double retorno = 0;

            retorno = Math.Pow(baseCuadrado, 2);
            return retorno;
        }

        public static double CalcularTriangulo(double baseTriangulo, double alturaTriangulo)
        {
            double retorno = 0;

            retorno = (baseTriangulo*alturaTriangulo)/2;
            return retorno;
        }

        public static double CalcularCirculo(double radioCirculo)
        {
            double retorno = 0;

            retorno = Math.PI * (Math.Pow(radioCirculo,2));
            return retorno;
        }
    }
}
