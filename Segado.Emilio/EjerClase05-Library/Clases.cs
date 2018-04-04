using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase05_Library
{
    public class Tinta
    {
        private ConsoleColor _color;
        private ETipoTinta _tipoTinta;

        public Tinta(ConsoleColor color2, ETipoTinta tipoTinta2)
        {
            this._color = color2;
            this._tipoTinta = tipoTinta2;
        }

        public Tinta()
            : this(ConsoleColor.Black, ETipoTinta.Comun)
        {
        }

        public Tinta(ConsoleColor color2)
            : this()
        {
            this._color = color2;
        }

        public Tinta(ETipoTinta tipoTinta2)
            : this()
        {
            this._tipoTinta = tipoTinta2;
        }

        private string Mostrar()
        {
            string retorno = "";

            retorno += "Color: ";
            retorno += this._color;
            retorno += "\nTipo de Tinta: ";
            retorno += this._tipoTinta;

            return retorno;
        }

        public static string Mostrar(Tinta tinta2)
        {
            return tinta2.Mostrar();
        }

        public static Boolean operator ==(Tinta tinta1, Tinta tinta2)
        {
            return tinta1._color == tinta2._color && tinta1._tipoTinta == tinta2._tipoTinta;
        }

        public static Boolean operator !=(Tinta tinta1, Tinta tinta2)
        {
            return !(tinta1 == tinta2); //Ahora codigo de hacer t1.tinta != t2.tinta || t1.tipoTinta != t2.tipoTinta, no aplica a otros operadores como + o -
        }
    }

    public class Pluma
    {
        private string _marca;
        private Tinta _tinta;
        private int _cantidad;

        public Pluma(string marca2, Tinta tinta2, int cantidad2)
        {
            this._marca = marca2;
            this._tinta = tinta2;
            this._cantidad = cantidad2;
        }

        public Pluma()
            : this("sin marca", new Tinta(), 0)
        {
        }

        public Pluma(string marca2)
            : this()
        {
            this._marca = marca2;
        }

        public Pluma(Tinta tinta2)
            : this()
        {
            this._tinta = tinta2;
        }

        public Pluma(int cantidad2)
            : this()
        {
            this._cantidad = cantidad2;
        }

        public Pluma(string marca2, int cantidad2)
            : this()
        {
            this._marca = marca2;
            this._cantidad = cantidad2;
        }

        public Pluma(string marca2, Tinta tinta2)
            : this()
        {
            this._marca = marca2;
            this._tinta = tinta2;
        }

        public Pluma(Tinta tinta2, int cantidad2)
            : this()
        {
            this._tinta = tinta2;
            this._cantidad = cantidad2;
        }

        private string Mostrar()
        {
            string cad = "";

            cad += "Marca: ";
            cad += this._marca;
            cad += "\n";
            cad += Tinta.Mostrar(this._tinta);
            cad += "\n";
            cad += "Cant Tinta: ";
            cad += this._cantidad;

            return cad;
        }

        public static implicit operator String(Pluma pluma2)
        {
            string retorno = pluma2.Mostrar();

            return retorno;
        }

        public static Boolean operator ==(Pluma pluma1, Tinta tinta2)
        {
            return pluma1._tinta == tinta2 && pluma1._tinta == tinta2;
        }

        public static Boolean operator !=(Pluma pluma1, Tinta tinta2)
        {
            return !(pluma1._tinta == tinta2);
        }

        public static Pluma operator +(Pluma pluma1, Tinta tinta2)
        {
            if (pluma1 == tinta2 && pluma1._cantidad < 100)
            {
                pluma1._cantidad++;
            }

            return pluma1;
        }

        public static Pluma operator -(Pluma pluma1, Tinta tinta2)
        {
            if (pluma1 == tinta2 && pluma1._cantidad > 0)
            {
                pluma1._cantidad--;
            }

            return pluma1;
        }
    }
}
