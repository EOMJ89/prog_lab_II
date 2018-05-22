using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase18_Interfaces_Libray
{
    #region Interfases
    public interface IAFIP
    { double CalcularImpuesto(); }

    public interface IARBA
    { double CalcularImpuesto(); }
    #endregion

    #region "Clase Estatica"
    public static class Gestion
    {
        public static double MostrarImpuestoNacional(IAFIP bienPunible)
        { return bienPunible.CalcularImpuesto(); }

        public static double MostrarImpuestoProvincial(IARBA bienPunible)
        { return bienPunible.CalcularImpuesto(); }
    }
    #endregion

    #region "Clase Base Vehiculo"
    public abstract class Vehiculo
    {
        protected Double _precio;

        public abstract void MostrarPrecio();

        public Vehiculo(double precio)
        { this._precio = precio; }
    }
    #endregion

    #region "Clases Hereradas Terrestres"
    public class Carreta : Vehiculo, IARBA
    {
        public Carreta(double precio) : base(precio) { }

        public override void MostrarPrecio()
        { Console.WriteLine("El precio de la Carreta es {0}", this._precio); }

        double IARBA.CalcularImpuesto()
        { return this._precio * 18 / 100; }
    }

    public abstract class Auto : Vehiculo
    {
        protected string _patente;

        public virtual double Precio { get { return this._precio; } }

        public Auto(double precio, string patente)
            : base(precio)
        { this._patente = patente; }

        public abstract void MostrarPatente();

        public override void MostrarPrecio()
        { Console.WriteLine("El precio del auto es {0}.", this._precio); }
    }

    #region "Clases Hereradas Auto"
    public class Familiar : Auto
    {
        protected int _cantAsientos;

        public Familiar(double precio, string patente, int cantAsientos)
            : base(precio, patente)
        { this._cantAsientos = cantAsientos; }

        public override void MostrarPatente()
        { Console.WriteLine("La patente del auto familiar es {0}.", this._patente); }
    }

    public class Deportivo : Auto, IAFIP, IARBA
    {
        protected int _caballosFuerza;

        public Deportivo(double precio, string patente, int hp)
            : base(precio, patente)
        { this._caballosFuerza = hp; }

        double IAFIP.CalcularImpuesto()
        { return this._precio * 28 / 100; }

        double IARBA.CalcularImpuesto()
        { return this._precio * 23 / 100; }

        public override void MostrarPatente()
        { Console.WriteLine("La patente del deportivo es {0}.", this._patente); }
    }
    #endregion

    #endregion

    #region "Clases Hereradas Aereas"
    public class Avion : Vehiculo, IAFIP, IARBA
    {
        private double _velocidadMaxima;

        public virtual double Precio { get { return this._precio; } }

        public Avion(double precio, double velMax)
            : base(precio)
        { this._velocidadMaxima = velMax; }

        double IAFIP.CalcularImpuesto()
        { return this._precio * 33 / 100; }

        double IARBA.CalcularImpuesto()
        { return this._precio * 27 / 100; }

        public override void MostrarPrecio()
        { Console.WriteLine("El precio del avion es {0}.", this._precio); }
    }

    #region "Clases Heredadas Avion"
    public class Privado : Avion
    {
        protected int _valoracionServicioDeAbordo;

        public Privado(double precio, double velocidad, int valoracion)
            : base(precio, velocidad)
        { this._valoracionServicioDeAbordo = valoracion; }
    }

    public class Comercial : Avion, IARBA
    {
        protected int _cantidadPasajeros;

        public Comercial(double precio, double velocidad, int pasajeros)
            : base(precio, velocidad)
        { this._cantidadPasajeros = pasajeros; }

        double IARBA.CalcularImpuesto()
        { return this._precio * 25 / 100; }
    }
    #endregion

    #endregion
}
