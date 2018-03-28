using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13
{
    class Conversor
    {
        public static string DecimalBinario(double aConvertir)
        {
            string auxString = "";

            while (aConvertir >= 1)
            {
                if (aConvertir % 2 == 0)
                {
                    auxString = "0" + auxString;
                }
                else
                {
                    auxString = "1" + auxString;
                }

                aConvertir = (int)aConvertir / 2;

            }

            return auxString;
        }

        public static double BinarioDecimal(string binario)
        {
            double auxDouble = 0;

            for (int i = binario.Length; i> 0; i--)
            {
                if (binario[i-1] == 49)
                {
                    auxDouble += Math.Pow(2,binario.Length-i);
                }
            }
            return auxDouble;
        }

    }
}
