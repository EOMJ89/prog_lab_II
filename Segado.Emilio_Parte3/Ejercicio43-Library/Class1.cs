using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio36_Library
{
    public class VehiculoDeCarrera
    {
        private string _escuderia;
        private Int16 _numero;
        private Int16 _cantidadCombustible;
        private Boolean _enCompetencia;
        private Int16 _vueltasRestantes;

        #region Propiedades
        public Int16 CantidadCombustible
        {
            get { return this._cantidadCombustible; }
            set { this._cantidadCombustible = value; }
        }

        public Boolean EnCompetencia
        {
            get { return this._enCompetencia; }
            set { this._enCompetencia = value; }
        }

        public Int16 VueltasRestantes
        {
            get { return this._vueltasRestantes; }
            set { this._vueltasRestantes = value; }
        }
        #endregion

        public VehiculoDeCarrera(Int16 numero, string escuderia)
        {
            this.CantidadCombustible = 0;
            this.EnCompetencia = false;
            this._escuderia = escuderia;
            this._numero = numero;
            this.VueltasRestantes = 0;
        }

        public virtual string MostrarDatos()
        {
            StringBuilder stringBuild = new StringBuilder();

            stringBuild.AppendFormat("AUTO N°{0}.\n", this._numero);
            stringBuild.AppendFormat("Escudería: {0}.\n", this._escuderia);
            stringBuild.AppendFormat("En Competencia: {0}.\n", this.EnCompetencia);
            stringBuild.AppendFormat("Tiene {0} litros de Combustible.\n", this.CantidadCombustible);
            stringBuild.AppendFormat("Vueltas restantes: {0}.\n", this.VueltasRestantes);

            return stringBuild.ToString();
        }

        public static Boolean operator ==(VehiculoDeCarrera a1, VehiculoDeCarrera a2)
        {
            Boolean retorno = false;

            if (a1._numero == a2._numero && a1._escuderia == a2._escuderia)
            { retorno = true; }
            return retorno;
        }

        public static Boolean operator !=(VehiculoDeCarrera a1, VehiculoDeCarrera a2)
        {
            return !(a1 == a2);
        }

    }

    public class AutoF1 : VehiculoDeCarrera
    {
        protected Int16 _caballosDeFuzerza;

        public Int16 CaballosDeFuerza
        {
            get { return this._caballosDeFuzerza; }
            set { this._caballosDeFuzerza = value; }
        }

        public AutoF1(Int16 numero, String escuderia) : base(numero, escuderia) { }

        public AutoF1(Int16 numero, String escuderia, Int16 caballosDeFuerza) : this(numero, escuderia)
        { this.CaballosDeFuerza = caballosDeFuerza; }

        public override string MostrarDatos()
        {
            StringBuilder stringBuild = new StringBuilder(base.MostrarDatos());
            stringBuild.AppendFormat("Caballos de fuerza: {0}.\n", this.CaballosDeFuerza);

            return stringBuild.ToString();
        }

        public static Boolean operator ==(AutoF1 a1, AutoF1 a2)
        {
            Boolean retorno = false;

            if ((VehiculoDeCarrera)a1 == (VehiculoDeCarrera)a2 && a1.CaballosDeFuerza == a2.CaballosDeFuerza) { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(AutoF1 a1, AutoF1 a2)
        { return !(a1 == a2); }
    }

    public class MotoCross : VehiculoDeCarrera
    {
        private Int16 _cilindrada;

        public Int16 Cilindrada
        {
            get { return this._cilindrada; }
            set { this._cilindrada = value; }
        }

        public MotoCross(Int16 numero, String escuderia) : base(numero, escuderia) { }

        public MotoCross(Int16 numero, String escuderia, Int16 cilindrada) : this(numero, escuderia)
        { this.Cilindrada = cilindrada; }

        public override string MostrarDatos()
        {
            StringBuilder stringBuild = new StringBuilder(base.MostrarDatos());
            stringBuild.AppendFormat("Cilindrada: {0}.\n", this.Cilindrada);

            return stringBuild.ToString();
        }

        public static Boolean operator ==(MotoCross a1, MotoCross a2)
        {
            Boolean retorno = false;

            if ((VehiculoDeCarrera)a1 == (VehiculoDeCarrera)a2 && a1.Cilindrada == a2.Cilindrada) { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(MotoCross a1, MotoCross a2)
        { return !(a1 == a2); }
    }

    public class Competencia
    {
        private Int16 _cantidadCompetidores;
        private Int16 _cantidadVueltas;
        private List<VehiculoDeCarrera> _competidores;
        private TipoCompetencia _tipo;

        public Int16 CantidadCompetidores
        {
            get { return this._cantidadCompetidores; }
            set { this._cantidadCompetidores = value; }
        }

        public Int16 CantidadVueltas
        {
            get { return this._cantidadVueltas; }
            set { this._cantidadVueltas = value; }
        }

        public VehiculoDeCarrera this[int i] { get { return this._competidores.ElementAt(i); } }

        public TipoCompetencia Tipo
        {
            get { return this._tipo; }
            set { this._tipo = value; }
        }

        #region Constructores
        private Competencia()
        { this._competidores = new List<VehiculoDeCarrera>(); }

        public Competencia(Int16 cantidadVueltas, Int16 cantidadCompetidores, TipoCompetencia tipo) : this()
        {
            this.CantidadCompetidores = cantidadCompetidores;
            this.CantidadVueltas = cantidadVueltas;
            this.Tipo = tipo;
        }
        #endregion

        public static Boolean operator +(Competencia c, VehiculoDeCarrera a)
        {
            Boolean retorno = false;
            Random combustible = new Random();

            if (c.CantidadCompetidores > c._competidores.Count)
            {
                try
                {
                    if (c != a)
                    {
                        a.EnCompetencia = true;
                        a.VueltasRestantes = c._cantidadVueltas;
                        a.CantidadCombustible = (Int16)combustible.Next(15, 100);
                        c._competidores.Add(a);
                        retorno = true;
                    }
                }
                catch (CompetenciaNoDisponibleException e)
                { throw new CompetenciaNoDisponibleException("Competencia Incorrecta", e); }
            }

            return retorno;
        }

        public static Boolean operator -(Competencia c, VehiculoDeCarrera a)
        {
            Boolean retorno = false;

            if (c == a)
            {
                c._competidores.Remove(a);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator ==(Competencia c, VehiculoDeCarrera a)
        {
            Boolean retorno = false;

            foreach (VehiculoDeCarrera autoA in c._competidores)
            {
                switch (c.Tipo)
                {
                    case TipoCompetencia.F1:
                        {
                            if (autoA is AutoF1)
                            {
                                if (a is AutoF1)
                                {
                                    if ((AutoF1)autoA == (AutoF1)a) { retorno = true; }
                                }
                                else { throw new CompetenciaNoDisponibleException("El vehiculo no pertenece a la competencia.", "Auto", "Comparar competencia a vehiculo"); }
                            }
                        }
                        break;
                    case TipoCompetencia.Motos:
                        {
                            if (autoA is MotoCross)
                            {
                                if (a is MotoCross)
                                {
                                    if ((MotoCross)autoA == (MotoCross)a) { retorno = true; }
                                }
                                else { throw new CompetenciaNoDisponibleException("El vehiculo no pertenece a la competencia.", "MotoCross", "Comparar competencia a vehiculo"); }
                            }
                        }
                        break;
                    default:
                        break;
                }
                break;
            }

            return retorno;
        }

        public static Boolean operator !=(Competencia c, VehiculoDeCarrera a)
        {
            return !(c == a);
        }

        public String MostrarDatos()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Cantidad de Vueltas: {0}\n", this._cantidadVueltas);
            stringBuild.AppendFormat("Cantidad de Competidores Maxima: {0}\n", this._cantidadCompetidores);
            stringBuild.AppendLine("*****************************");
            stringBuild.AppendLine("Competidores:");
            stringBuild.AppendLine("*****************************");

            foreach (VehiculoDeCarrera autoA in this._competidores)
            {
                if (autoA is AutoF1)
                { stringBuild.AppendLine(((AutoF1)autoA).MostrarDatos()); }
                else if (autoA is MotoCross)
                { stringBuild.AppendLine(((MotoCross)autoA).MostrarDatos()); }
            }

            return stringBuild.ToString();
        }

        public enum TipoCompetencia
        { F1, Motos }
    }

    public class CompetenciaNoDisponibleException : Exception
    {
        public string _nombreClase;
        public string _nombreMetodo;

        public string NombreClase { get { return this._nombreClase; } }

        public string NombreMetodo { get { return this._nombreMetodo; } }


        public CompetenciaNoDisponibleException(string message, Exception inner) : base(message, inner) { }


        public CompetenciaNoDisponibleException(string mensaje, string clase, string metodo) : base(mensaje)
        {
            this._nombreClase = clase;
            this._nombreMetodo = metodo;
        }

        public CompetenciaNoDisponibleException(string mensaje, string clase, string metodo, Exception innerException) : base(mensaje, innerException)
        {
            this._nombreClase = clase;
            this._nombreMetodo = metodo;
        }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Excepcion en el metodo {0} de la clase {1}.", this.NombreMetodo, this.NombreClase);
            stringBuild.AppendLine(this.Message);
            stringBuild.AppendLine(base.ToString());

            return stringBuild.ToString();
        }
    }
}
