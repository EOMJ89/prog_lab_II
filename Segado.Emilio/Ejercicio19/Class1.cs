using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio19
{
    class Sumador
    {
        private int cantidadSumas;

        public Sumador(int sumas)
        {
            this.cantidadSumas = sumas;
        }

        public Sumador() : this(0)
        { }

        public long Sumar(long a, long b)
        {
            return a + b;
        }

        public string Sumar(string a, string b)
        {
            return a + b;
        }

        public static implicit operator int(Sumador sumador2)
        {
            return sumador2.cantidadSumas;
        }

        public static long operator +(Sumador sumador1, Sumador sumador2)
        {
            return sumador1.cantidadSumas + sumador2.cantidadSumas;
        }

        public static Boolean operator |(Sumador sumador1, Sumador sumador2)
        {
            Boolean retorno = false;

            if (sumador1.cantidadSumas == sumador2.cantidadSumas)
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
