using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio38
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nº38 Guía 2017";

            SobreSobreescrito sobrecarga = new SobreSobreescrito();

            Console.WriteLine(sobrecarga.ToString());
            string objeto = "¡Este es mi método ToString sobreescrito!";
            Console.WriteLine("----------------------------------------------");
            Console.Write("Comparación Sobrecargas con String: ");
            Console.WriteLine(sobrecarga.Equals(objeto));
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(sobrecarga.GetHashCode()); Console.WriteLine("----------------------------------------------");
            Console.WriteLine(sobrecarga.MiMetodo());

            Console.ReadLine();
        }
    }

    public abstract class Sobreescrito
    {
        protected string _miAtributo;


        public string MiAtributo { get { return this._miAtributo; } }

        public Sobreescrito() { this._miAtributo = "Probar Abstractos"; }

        public override string ToString()
        {
            return "¡Este es mi método ToString sobreescrito!";
        }

        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Sobreescrito)
            {
                if ((Sobreescrito)obj == this)
                { retorno = true; }
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return 1142510187;
        }

        public abstract string MiMetodo();
    }

    public class SobreSobreescrito : Sobreescrito
    { public override string MiMetodo()
        { return base.MiAtributo; } }
}