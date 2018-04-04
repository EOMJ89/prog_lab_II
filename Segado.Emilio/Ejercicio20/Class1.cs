using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio20
{
    class Dolar
    {
        private double _cantidad;
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

        public double GetCantidad()
        {
            return this._cantidad;
        }

        public static explicit operator Euro(Dolar dolar2)
        {
            Euro euro2 = new Euro(dolar2.GetCantidad() * 1.3642);
            return euro2;
        }

        public static explicit operator Peso(Dolar dolar2)
        {
            Peso peso2 = new Peso(dolar2.GetCantidad() * 17.55);
            return peso2;
        }

        public static implicit operator Dolar(double d)
        {
            Dolar dolar2 = new Dolar(d);
            return dolar2;
        }

        public static Dolar operator +(Dolar dolar1, Euro euro1)
        {
            Dolar dolar3 = new Dolar(dolar1.GetCantidad() + ((Dolar)euro1).GetCantidad());
            return dolar3;
        }

        public static Dolar operator -(Dolar dolar1, Euro euro1)
        {
            Dolar dolar3 = new Dolar(dolar1.GetCantidad() - ((Dolar)euro1).GetCantidad());
            return dolar3;
        }

        public static Dolar operator +(Dolar dolar1, Peso peso1)
        {
            Dolar dolar3 = new Dolar(dolar1.GetCantidad() + ((Dolar)peso1).GetCantidad());
            return dolar3;
        }

        public static Dolar operator -(Dolar dolar1, Peso peso1)
        {
            Dolar dolar3 = new Dolar(dolar1.GetCantidad() - ((Dolar)peso1).GetCantidad());
            return dolar3;
        }
    }

    class Euro
    {
        private double _cantidad;
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

        public double GetCantidad()
        {
            return this._cantidad;
        }

        public static explicit operator Dolar(Euro euro2)
        {
            Dolar dolar2 = new Dolar(euro2.GetCantidad() / 1.3642);
            return dolar2;
        }

        public static explicit operator Peso(Euro euro2)
        {
            Peso peso2 = new Peso((euro2.GetCantidad() * 1.3641)*17.55);
            return peso2;
        }

        public static implicit operator Euro(double d)
        {
            Euro euro2 = new Euro(d);
            return euro2;
        }

        public static Euro operator +(Euro euro1, Dolar dolar1)
        {
            Euro euro3 = new Euro(euro1.GetCantidad() + ((Euro)dolar1).GetCantidad());
            return euro3;
        }

        public static Euro operator -(Euro euro1, Dolar dolar1)
        {
            Euro euro3 = new Euro(euro1.GetCantidad() - ((Euro)dolar1).GetCantidad());
            return euro3;
        }
        
        public static Euro operator +(Euro euro1, Peso peso1)
        {
            Euro euro3 = new Euro(euro1.GetCantidad() + ((Euro)peso1).GetCantidad());
            return euro3;
        }

        public static Euro operator -(Euro euro1, Peso peso1)
        {
            Euro euro3 = new Euro(euro1.GetCantidad() - ((Euro)peso1).GetCantidad());
            return euro3;
        }
    }

    class Peso
    {
        private double _cantidad;
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

        public double GetCantidad()
        {
            return this._cantidad;
        }

        public static explicit operator Dolar(Peso peso2)
        {
            Dolar dolar2 = new Dolar(peso2.GetCantidad() / 17.55);
            return dolar2;
        }

        public static explicit operator Euro(Peso peso2)
        {
            Euro euro2 = new Euro((peso2.GetCantidad() / 17.55) / 1,3642);
            return euro2;
        }

        public static implicit operator Peso(double d)
        {
            Peso peso2 = new Peso(d);
            return peso2;
        }

        public static Peso operator +(Peso pesos1, Dolar dolar1)
        {
            Peso peso3 = new Peso (pesos1.GetCantidad() + ((Peso)dolar1).GetCantidad());
            return peso3;
        }

        public static Peso operator -(Peso pesos1, Dolar dolar1)
        {
            Peso peso3 = new Peso(pesos1.GetCantidad() - ((Peso)dolar1).GetCantidad());
            return peso3;
        }

        public static Peso operator +(Peso pesos1, Euro euro1)
        {
            Peso peso3 = new Peso(pesos1.GetCantidad() + ((Peso)euro1).GetCantidad());
            return peso3;
        }

        public static Peso operator -(Peso pesos1, Euro euro1)
        {
            Peso peso3 = new Peso(pesos1.GetCantidad() - ((Peso)euro1).GetCantidad());
            return peso3;
        }
    }
}
