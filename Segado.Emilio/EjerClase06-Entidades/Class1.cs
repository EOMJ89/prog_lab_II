using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase06_Entidades
{
    public class Tempera
    {
        private ConsoleColor _color;
        private string _marca;
        private Int32 _cantidad;

        public Tempera(ConsoleColor color2, string marca2, Int32 cantidad2)
        {
            this._cantidad = cantidad2;
            this._color = color2;
            this._marca = marca2;
        }

        private string Mostrar()
        {
            string cad = "";
            cad += this._marca;
            cad += " - ";
            cad += this._color;
            cad += " - ";
            cad += this._cantidad;

            return cad;
        }

        public static string Mostrar(Tempera tempera2)
        {
            return tempera2.Mostrar();
        }

        public static bool operator ==(Tempera t1, Tempera t2)
        {
            bool retorno = false;

            if (t1._marca == t2._marca && t1._color == t2._color)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Tempera t1, Tempera t2)
        {
            return !(t1 == t2);
        }

        public static implicit operator int(Tempera t1)
        {
            return t1._cantidad;
        }

        public static explicit operator string(Tempera t1)
        {
            return t1.Mostrar();
        }

        public static Tempera operator +(Tempera t1, int sumar)
        {
            t1._cantidad += sumar;
            return t1;
        }

        public static Tempera operator +(Tempera t1, Tempera t2)
        {
            if (t1 == t2)
            {
                t1 += t2._cantidad;
            }
            return t1;
        }

        public static Tempera operator -(Tempera t1, int sumar)
        {
            t1._cantidad -= sumar;
            return t1;
        }

        public static Tempera operator -(Tempera t1, Tempera t2)
        {
            if (t1 == t2)
            {
                t1 -= t2._cantidad;
            }
            return t1;
        }
    }

    public class Paleta
    {
        private Tempera[] _colores;
        private int _cantidadMaximaColores;

        private Paleta(int colores)
        {
            this._cantidadMaximaColores = colores;
            this._colores = new Tempera[this._cantidadMaximaColores];
        }

        private Paleta()
            : this(5)
        { }

        public static implicit operator Paleta(int cant)
        {
            Paleta paleta1 = new Paleta(cant);
            return paleta1;
        }

        private string Mostrar()
        {
            string cad = "";
            cad += "Cantidad de Colores: " + this._cantidadMaximaColores;
            foreach (Tempera temperaA in this._colores)
            {
                if (((object)temperaA) != null)
                {
                    cad += "\n" + Tempera.Mostrar(temperaA);
                }
            }

            //for (int i = 0; i < this._cantidadMaximaColores; i++)
            //{
            //    if(this._colores.GetValue(i) != null)
            //    {
            //        cad += "\n" + Tempera.Mostrar(this._colores[i]) + "\n";
            //    }
            //}

            return cad;
        }

        public static explicit operator string(Paleta paleta1)
        {
            return paleta1.Mostrar();
        }

        public static Boolean operator ==(Paleta paleta1, Tempera tempera1)
        {
            Boolean retorno = false;

            foreach (Tempera temperaA in paleta1._colores)
            {
                if (((object)temperaA) != null)
                {
                    if (temperaA == tempera1)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static Boolean operator !=(Paleta paleta1, Tempera tempera1)
        {
            return !(paleta1 == tempera1);
        }

        private int ObtenerIndice()
        {
            int indice = -1;

            for (int i = 0; i < this._cantidadMaximaColores; i++)
            {
                if (this._colores.GetValue(i) == null)
                {
                    indice = i;
                    break;
                }
            }

            return indice;
        }

        private int ObtenerIndice(Tempera tempera1)
        {
            int indice = -1;

            for (int i = 0; i < this._cantidadMaximaColores; i++)
            {
                if (this._colores.GetValue(i) != null)
                {
                    if (this._colores[i] == tempera1)
                    {
                        indice = i;
                        break;
                    }
                }
            }

            return indice;
        }

        public static Paleta operator +(Paleta paleta1, Tempera tempera1)
        {
            if (((object)tempera1) != null && ((object)paleta1) !=null)
            {
                if (paleta1 == tempera1)
                {
                    paleta1._colores[paleta1.ObtenerIndice(tempera1)] += tempera1;
                }
                else
                {
                    paleta1._colores[paleta1.ObtenerIndice()] = tempera1;
                }
            }
            return paleta1;
        }

        public static Paleta operator -(Paleta paleta1, Tempera tempera1)
        {
            if (((object)tempera1) != null && ((object)paleta1) != null)
            {
                if (paleta1 == tempera1)
                {
                    int indiceTempera1 = paleta1.ObtenerIndice(tempera1);

                    if (paleta1._colores[indiceTempera1] - tempera1 <= 0)
                    {
                        paleta1._colores[indiceTempera1] = null;
                    }
                }
            }

            return paleta1;
        }
    }
}
