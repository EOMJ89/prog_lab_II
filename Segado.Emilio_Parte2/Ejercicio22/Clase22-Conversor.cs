using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio22
{
    public class Conversor
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

            for (int i = binario.Length; i > 0; i--)
            {
                if (binario[i - 1] == 49)
                {
                    auxDouble += Math.Pow(2, binario.Length - i);
                }
            }
            return auxDouble;
        }
    }

    public class NumeroBinario
    {
        public string _numero;

        public NumeroBinario(string numero)
        { this._numero = numero; }

        public static string operator +(NumeroBinario nB, NumeroDecimal nD)
        {
            double auxNumero = Conversor.BinarioDecimal(nB._numero);
            string retorno = Conversor.DecimalBinario(auxNumero += nD._numero);

            return retorno;
        }

        public static string operator -(NumeroBinario nB, NumeroDecimal nD)
        {
            double auxNumero = Conversor.BinarioDecimal(nB._numero);
            string retorno = Conversor.DecimalBinario(auxNumero -= nD._numero);

            return retorno;
        }

        public static Boolean operator ==(NumeroBinario nB, NumeroDecimal nD)
        {
            double auxNumero = Conversor.BinarioDecimal(nB._numero);
            Boolean retorno = false;

            if (auxNumero == nD._numero)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(NumeroBinario nB, NumeroDecimal nD)
        {
            return !(nB == nD);
        }

        public static implicit operator NumeroBinario(string numero)
        { return new NumeroBinario(numero); }

        public static explicit operator string(NumeroBinario numero)
        { return numero._numero; }
    }

    public class NumeroDecimal
    {
        public double _numero;

        public NumeroDecimal(double numero)
        { this._numero = numero; }

        public static Double operator +(NumeroDecimal nD, NumeroBinario nB)
        {
            nD._numero += Conversor.BinarioDecimal(nB._numero);

            return nD._numero;
        }

        public static Double operator -(NumeroDecimal nD, NumeroBinario nB)
        {
            nD._numero -= Conversor.BinarioDecimal(nB._numero);

            return nD._numero;
        }

        public static Boolean operator ==(NumeroDecimal nD, NumeroBinario nB)
        {
            double auxNumero = Conversor.BinarioDecimal(nB._numero);
            Boolean retorno = false;

            if (auxNumero == nD._numero)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(NumeroDecimal nD, NumeroBinario nB)
        {
            return !(nB == nD);
        }

        public static implicit operator NumeroDecimal(double numero)
        { return new NumeroDecimal(numero); }

        public static explicit operator Double(NumeroDecimal numero)
        { return numero._numero; }
    }
}
