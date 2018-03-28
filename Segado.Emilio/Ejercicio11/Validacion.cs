using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    class Validacion
    {
        public static bool Validar(int valor, int min, int max)
        {
            Boolean retorno = false;

            if(valor > min && valor < max)
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
