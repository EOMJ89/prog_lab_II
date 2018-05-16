using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio47_Library
{
    public class Documento
    {
        protected int _numero;

        public Documento(int numero)
        { this._numero = numero; }

        public override string ToString()
        {
            return this._numero.ToString();
        }
    }

    public class Recibo : Documento
    {
        public Recibo() : this(0) { }

        public Recibo(int numero) : base(numero) { }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Factura : Documento
    {
        public Factura(int numero) : base(numero) { }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Contabilidad<T, U>
        where T : Documento
        where U : Documento, new() //Restricciones multiples requieren usar ","
    {
        private List<T> _egresos;
        private List<U> _ingresos;

        public Contabilidad()
        {
            this._egresos = new List<T>();
            this._ingresos = new List<U>();
        }

        public static Contabilidad<T, U> operator +(Contabilidad<T, U> c, T egreso)
        {
            Contabilidad<T, U> aux = c;//No requiere validar porque la unica otra chance ya está en sobrecargas
            aux._egresos.Add(egreso);

            return c;
        }

        public static Contabilidad<T, U> operator +(Contabilidad<T, U> c, U ingreso)
        {
            Contabilidad<T, U> aux = c; //No requiere validar porque la unica otra chance ya está en sobrecargas
            aux._ingresos.Add(ingreso);

            return aux;
        }

        public string ToString(string tText, string uText)
        {
            StringBuilder stringBuild = new StringBuilder();

            stringBuild.AppendFormat("Lista de {0}:\n", tText);
            foreach (T tAux in this._egresos)
            { stringBuild.AppendLine(tAux.ToString()); }

            stringBuild.AppendFormat("Lista de {0}:\n", uText);
            foreach (U uAux in this._ingresos)
            { stringBuild.AppendLine(uAux.ToString()); }

            return stringBuild.ToString();
        }
    }
}
