using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billetes
{
    class Euro
    {
        public double _cantidad;
        private float _cotizRespectoDolar;

        public Euro(double cantidad, float cotizacion)
        {
            this._cantidad = cantidad;
            this._cotizRespectoDolar = cotizacion;
        }

        private Euro() : this(0, (float)1.3642)
        { }

        public Euro(double cantidad) : this()
        {
            this._cantidad = cantidad;
        }

        public float GetCotizacion()
        {
            return this._cotizRespectoDolar;
        }

        public static explicit operator Dolar(Euro euro1)
        {
            Dolar dolar2 = new Dolar(euro1._cantidad * euro1._cotizRespectoDolar);
            return dolar2;
        }

        public static explicit operator Peso(Euro euro1)
        {
            Dolar dolar2 = new Dolar(0);
            Peso peso2 = new Peso(euro1._cantidad * dolar2.GetCotizacion() * euro1._cotizRespectoDolar);
            return peso2;
        }

        public static implicit operator Euro(double d)
        {
            Euro euro2 = new Euro(d);
            return euro2;
        }

        public static Euro operator +(Euro euro1, Dolar dolar1)
        {
            Euro euro2 = new Euro(euro1._cantidad + ((Euro)dolar1)._cantidad);

            return euro2;
        }

        public static Euro operator +(Euro euro1, Peso peso2)
        {
            Euro euro2 = new Euro(euro1._cantidad + ((Euro)peso2)._cantidad);

            return euro2;
        }

        public static Euro operator -(Euro euro1, Dolar dolar1)
        {
            Euro euro2 = new Euro(euro1._cantidad - ((Euro)dolar1)._cantidad);

            return euro2;
        }

        public static Euro operator -(Euro euro1, Peso peso2)
        {
            Euro euro2 = new Euro(euro1._cantidad - ((Euro)peso2)._cantidad);

            return euro2;
        }

        public static Boolean operator ==(Euro euro1, Dolar dolar1)
        {
            Boolean retorno = false;
            if (euro1._cantidad == Math.Round(((Euro)dolar1)._cantidad,4))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Euro euro1, Dolar dolar1)
        { return !(euro1 == dolar1); }

        public static Boolean operator ==(Euro euro1, Peso peso1)
        {
            Boolean retorno = false;
            if (euro1._cantidad == Math.Round(((Euro)peso1)._cantidad,2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Euro euro1, Peso peso1)
        { return !(euro1 == peso1); }

        public static Boolean operator ==(Euro euro1, Euro euro2)
        {
            Boolean retorno = false;
            if (euro1._cantidad == euro2._cantidad)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Euro euro1, Euro euro2)
        { return !(euro1 == euro2); }
    }

    class Dolar
    {
        public double _cantidad;
        private float _cotizRespectoDolar;

        public Dolar(double cantidad, float cotizacion)
        {
            this._cantidad = cantidad;
            this._cotizRespectoDolar = cotizacion;
        }

        private Dolar() : this(0, 1)
        { }

        public Dolar(double cantidad) : this()
        {
            this._cantidad = cantidad;
        }

        public float GetCotizacion()
        {
            return this._cotizRespectoDolar;
        }

        public static explicit operator Euro(Dolar dolar1)
        {
            Euro euro1 = new Euro(0);
            Euro euro2 = new Euro(dolar1._cantidad / euro1.GetCotizacion());
            return euro2;
        }

        public static explicit operator Peso(Dolar dolar1)
        {
            Peso peso1 = new Peso(0);
            Peso peso2 = new Peso(dolar1._cantidad * peso1.GetCotizacion());
            return peso2;
        }

        public static implicit operator Dolar(double d)
        {
            Dolar dolar2 = new Dolar(d);
            return dolar2;
        }

        public static Dolar operator +(Dolar dolar1, Euro euro1)
        {
            Dolar dolar2 = new Dolar(dolar1._cantidad + ((Dolar)euro1)._cantidad);

            return dolar2;
        }

        public static Dolar operator -(Dolar dolar1, Euro euro1)
        {
            Dolar dolar2 = new Dolar(dolar1._cantidad - ((Dolar)euro1)._cantidad);

            return dolar2;
        }

        public static Dolar operator +(Dolar dolar1, Peso peso1)
        {
            Dolar dolar2 = new Dolar(dolar1._cantidad + ((Dolar)peso1)._cantidad);

            return dolar2;
        }

        public static Dolar operator -(Dolar dolar1, Peso peso1)
        {
            Dolar dolar2 = new Dolar(dolar1._cantidad - ((Dolar)peso1)._cantidad);

            return dolar2;
        }

        public static Boolean operator ==(Dolar dolar1, Euro euro1)
        {
            Boolean retorno = false;
            if (dolar1._cantidad == Math.Round(((Dolar)euro1)._cantidad,4))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Dolar dolar1, Euro euro1)
        { return !(dolar1 == euro1); }

        public static Boolean operator ==(Dolar dolar1, Peso peso1)
        {
            Boolean retorno = false;
            if (dolar1._cantidad == Math.Round(((Dolar)peso1)._cantidad,2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Dolar dolar1, Peso peso1)
        { return !(dolar1 == peso1); }

        public static Boolean operator ==(Dolar dolar1, Dolar dolar2)
        {
            Boolean retorno = false;
            if (dolar1._cantidad == dolar2._cantidad)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Dolar dolar1, Dolar dolar2)
        { return !(dolar1 == dolar2); }

    }

    class Peso
    {
        public double _cantidad;
        private float _cotizRespectoDolar;

        public Peso(double cantidad, float cotizacion)
        {
            this._cantidad = cantidad;
            this._cotizRespectoDolar = cotizacion;
        }

        private Peso() : this(0, (float)17.55)
        { }

        public Peso(double cantidad) : this()
        {
            this._cantidad = cantidad;
        }

        public float GetCotizacion()
        {
            return this._cotizRespectoDolar;
        }

        public static explicit operator Dolar(Peso peso1)
        {
            Dolar dolar2 = new Dolar(peso1._cantidad / peso1.GetCotizacion());
            return dolar2;
        }

        public static explicit operator Euro(Peso peso1)
        {
            Euro euro1 = new Euro(0);
            Euro euro2 = new Euro(peso1._cantidad / peso1.GetCotizacion() / euro1.GetCotizacion());
            return euro2;
        }

        public static implicit operator Peso(double d)
        {
            Peso peso2 = new Peso(d);
            return peso2;
        }

        public static Peso operator +(Peso peso1, Dolar dolar1)
        {
            Peso peso2 = new Peso(peso1._cantidad + ((Peso)dolar1)._cantidad);

            return peso2;
        }

        public static Peso operator -(Peso peso1, Dolar dolar1)
        {
            Peso peso2 = new Peso(peso1._cantidad - ((Peso)dolar1)._cantidad);

            return peso2;
        }

        public static Peso operator +(Peso peso1, Euro euro1)
        {
            Peso peso2 = new Peso(peso1._cantidad + ((Peso)euro1)._cantidad);

            return peso2;
        }

        public static Peso operator -(Peso peso1, Euro euro1)
        {
            Peso peso2 = new Peso(peso1._cantidad - ((Peso)euro1)._cantidad);

            return peso2;
        }

        public static Boolean operator ==(Peso peso1, Euro euro1)
        {
            Boolean retorno = false;
            if (peso1._cantidad == Math.Round(((Peso)euro1)._cantidad, 2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Peso peso1, Euro euro1)
        { return !(peso1 == euro1); }

        public static Boolean operator ==(Peso peso1, Dolar dolar1)
        {
            Boolean retorno = false;
            if (peso1._cantidad == Math.Round(((Peso)dolar1)._cantidad, 2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Peso peso1, Dolar dolar1)
        { return !(peso1 == dolar1); }

        public static Boolean operator ==(Peso peso1, Peso peso2)
        {
            Boolean retorno = false;
            if (peso1._cantidad == peso2._cantidad)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Peso peso1, Peso peso2)
        { return !(peso1 == peso2); }
    }
}
