﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase08
{
    public class Vehiculo
    {
        protected string _patente;
        protected byte _cantRuedas;
        protected EMarcas _marca;

        public string Patente
        {
            get { return this._patente; }
        }

        public EMarcas Marca
        {
            get { return this._marca; }
        }

        protected string Mostrar()
        { return ("Patente: " + this.Patente + " Marca: " + this.Marca + " Cant Ruedas: " + this._cantRuedas); }

        public Vehiculo(string patente, byte cantRuedas, EMarcas marca)
        {
            this._patente = patente;
            this._cantRuedas = cantRuedas;
            this._marca = marca;
        }

        public static Boolean operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            Boolean retorno = false;
            if (vehiculo1.Patente == vehiculo2.Patente && vehiculo1.Marca == vehiculo2.Marca)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        { return !(vehiculo1 == vehiculo2); }
    }

    public class Auto : Vehiculo
    {
        protected int _cantidadAsientos;

        public string MostrarAuto()
        {
            return (base.Mostrar() + " Cant Asientos: " + this._cantidadAsientos + "\n");
        }

        public Auto(string patente, byte cantRuedas, EMarcas marca, int cantAsientos)
            : base(patente, cantRuedas, marca)
        {
            this._cantidadAsientos = cantRuedas;
        }
    }

    public class Camion : Vehiculo
    {
        protected float _tara;

        public string MostrarCamion()
        {
            return (base.Mostrar() + " Tara " + this._tara + "\n");
        }

        public Camion(string patente, byte cantRuedas, EMarcas marca, float tara)
            : base(patente, cantRuedas, marca)
        {
            this._tara = tara;
        }
    }

    public class Moto : Vehiculo
    {
        protected float _cilindrada;

        public string MostrarMoto()
        {
            return (base.Mostrar() + " Cilindrada " + this._cilindrada + "\n");
        }

        public Moto(string patente, byte cantRuedas, EMarcas marca, float cilindrada)
            : base(patente, cantRuedas, marca)
        {
            this._cilindrada = cilindrada;
        }
    }

    public class Lavadero
    {
        protected List<Vehiculo> _vehiculos;
        protected float _precioAuto;
        protected float _precioCamion;
        protected float _precioMoto;

        private Lavadero()
        {
            this._vehiculos = new List<Vehiculo>(); //Al ser Auto,Camio y Moto clases heredadas, el list permitirá agregarlos, pero se debe usar el boxing y el unboxing
        }

        public Lavadero(float precioAuto, float precioCamion, float precioMoto)
            : this()
        {
            this._precioAuto = precioAuto;
            this._precioCamion = precioCamion;
            this._precioMoto = precioMoto;
        }

        public string LavaderoAll
        {
            get
            {
                return "Precio Auto: " + this._precioAuto + " Precio Camion: " + this._precioCamion + " Precio Moto: " + this._precioMoto + "\n" + this.Vehiculos;
            }
        }

        public string Vehiculos
        {
            get
            {
                string retorno = "";
                foreach (Vehiculo vehiculoA in this._vehiculos)
                {
                    if (vehiculoA is Auto)
                    { retorno += ((Auto)vehiculoA).MostrarAuto(); }
                    else if (vehiculoA is Camion)
                    { retorno += ((Camion)vehiculoA).MostrarCamion(); }
                    else if (vehiculoA is Moto)
                    { retorno += ((Moto)vehiculoA).MostrarMoto(); }
                }

                return retorno;
            }
        }

        public double MostrarTotalFacturado(EVehiculo tipoVehiculo)
        {
            double retorno = 0;
            int contAuto = 0, contCamion = 0, contMotos = 0;

            foreach (Vehiculo vehiculoA in this._vehiculos)
            {
                if (vehiculoA is Auto)
                { contAuto++; }
                else if (vehiculoA is Camion)
                { contCamion++; }
                else if (vehiculoA is Moto)
                { contMotos++; }

                //Metodo propio
                //switch (tipoVehiculo)
                //{
                //    case EVehiculo.Auto:
                //        {
                //            if (vehiculoA is Auto)
                //            {
                //                retorno += this._precioAuto;
                //            }
                //            break;
                //        }
                //    case EVehiculo.Camion:
                //        {
                //            if (vehiculoA is Camion)
                //            {
                //                retorno += this._precioCamion;
                //            }
                //            break;
                //        }
                //    case EVehiculo.Moto:
                //        {
                //            if (vehiculoA is Moto)
                //            {
                //                retorno += this._precioMoto;
                //            }
                //            break;
                //    default:
                //    break;
                //        }
                //}
            }

            switch (tipoVehiculo)
            {
                case EVehiculo.Auto:
                    {
                        retorno = this._precioAuto * contAuto;
                        break;
                    }
                case EVehiculo.Camion:
                    {
                        retorno = this._precioCamion * contCamion;
                        break;
                    }
                case EVehiculo.Moto:
                    {
                        retorno = this._precioMoto * contMotos;
                        break;
                    }
                default:
                    break;
            }

            return retorno;
        }

        public double MostrarTotalFacturado()
        {
            return (this.MostrarTotalFacturado(EVehiculo.Auto) + this.MostrarTotalFacturado(EVehiculo.Camion) + this.MostrarTotalFacturado(EVehiculo.Moto));
        }

        public static Boolean operator ==(Lavadero lavadero1, Vehiculo vehiculo2)
        {
            Boolean retorno = false;

            foreach (Vehiculo vehiculoA in lavadero1._vehiculos) //por cada Vehiculo en la lista
            {
                if (vehiculoA == vehiculo2)
                {
                    retorno = true; //Flag para demostrar que el jugador ya está en el equipo
                    break; //No hace falta seguir buscando
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Lavadero lavadero1, Vehiculo vehiculo2)
        { return !(lavadero1 == vehiculo2); }

        public static Lavadero operator +(Lavadero lavadero1, Vehiculo vehiculo1)
        {
            Boolean flag = false;

            foreach (Vehiculo vehiculoA in lavadero1._vehiculos) //por cada jugador en la lista
            {
                if (vehiculoA == vehiculo1)
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                lavadero1._vehiculos.Add(vehiculo1);
            }
            
            return lavadero1;
        }

        public static Lavadero operator -(Lavadero lavadero1, Vehiculo vehiculo1)
        {
            foreach (Vehiculo vehiculoA in lavadero1._vehiculos) //Por cada jugador en la lista
            {
                if (vehiculoA == vehiculo1)
                {
                    int indexVehiculo = lavadero1._vehiculos.IndexOf(vehiculo1);
                    lavadero1._vehiculos.RemoveAt(indexVehiculo);
                    break; //No hace falta buscar más
                }
            }

            return lavadero1;
        }

        //public static int OrdernarVehiculosPorPatente(Vehiculo vehiculo1, Vehiculo vehiculo2)
        //{ 
        //}
    }
}