using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestamosPersonales;

namespace PrestamosPersonales
{
    #region "Enumerados"
    public enum PeriodicidadDePagos
    { Mensual, Bimestral, Trimestral }

    public enum TipoDePrestamo
    { Pesos, Dolares, Todos }
    #endregion

    public abstract class Prestamo
    {
        protected float _monto;
        protected DateTime _vencimiento;

        #region "Propiedades"
        public float Monto
        { get { return this._monto; } }

        public DateTime Vencimiento
        {
            get { return this._vencimiento; }
            set
            {
                if (value < DateTime.Today)
                { this._vencimiento = DateTime.Today; }
                else
                { this._vencimiento = value; }
            }
        }
        #endregion

        #region "Constructores"
        public Prestamo(float monto, DateTime vencimiento)
        {
            this._monto = monto;
            this.Vencimiento = vencimiento;
        }
        #endregion

        #region "Metodos"
        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

        public virtual string Mostrar()
        { return string.Format("Monto: {0}\nVencimiento: {1:dd/MM/yyyy}", this.Monto, this.Vencimiento); }

        public static Int32 OrdenarPorFecha(Prestamo prestamo1, Prestamo prestamo2)
        {
            Int32 retorno = 0;

            if (prestamo1.Vencimiento > prestamo2.Vencimiento)
            { retorno = 1; }
            else if (prestamo1.Vencimiento < prestamo2.Vencimiento)
            { retorno = -1; }

            return retorno;
        }
        #endregion
    }

    public class PrestamoDolar : Prestamo
    {
        private PeriodicidadDePagos _periodicidad;

        #region "Propiedades"
        public float Interes
        { get { return this.CalcularInteres(); } }

        public PeriodicidadDePagos Periodicidad
        { get { return this._periodicidad; } }
        #endregion

        #region "Constructores"
        public PrestamoDolar(Prestamo prestamo, PeriodicidadDePagos periodicidad) : this(prestamo.Monto, prestamo.Vencimiento, periodicidad)
        { }

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad) : base(monto, vencimiento)
        { this._periodicidad = periodicidad; }
        #endregion

        #region "Metodos"
        private float CalcularInteres()
        {
            float retorno = 0;

            switch (this.Periodicidad)
            {
                case PeriodicidadDePagos.Mensual:
                    {
                        retorno = this.Monto * 25 / 100;
                    }
                    break;
                case PeriodicidadDePagos.Bimestral:
                    {
                        retorno = this.Monto * 35 / 100;
                    }
                    break;
                case PeriodicidadDePagos.Trimestral:
                    {
                        retorno = this.Monto * 40 / 100;
                    }
                    break;
                default:
                    break;
            }

            return retorno;
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferenciaDias = nuevoVencimiento.Subtract(this.Vencimiento);
            this._monto += (2.5f * diferenciaDias.Days);

            this.Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendLine(base.Mostrar());
            stringBuild.AppendFormat("Periodicidad: {0}\n", this.Periodicidad.ToString());
            stringBuild.AppendFormat("Interes de: {0:#.##}", this.Interes);

            return stringBuild.ToString();
        }
        #endregion
    }

    public class PrestamoPesos : Prestamo
    {
        private float _porcentajeInteres;

        #region "Propiedades"
        public float Interes
        { get { return this.CalcularInteres(); } }
        #endregion

        #region "Constructores"
        public PrestamoPesos(Prestamo prestamo, float interes) : this(prestamo.Monto, prestamo.Vencimiento, interes)
        { }

        public PrestamoPesos(float monto, DateTime vencimiento, float interes) : base(monto, vencimiento)
        { this._porcentajeInteres = interes; }
        #endregion

        #region "Metodos"
        private float CalcularInteres()
        { return this.Monto * this._porcentajeInteres / 100; }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferenciaDias = nuevoVencimiento.Subtract(this.Vencimiento);
            this._porcentajeInteres += (0.25f * diferenciaDias.Days);

            this.Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendLine(base.Mostrar());
            stringBuild.AppendFormat("Interes del: {0}%\n", this._porcentajeInteres);
            stringBuild.AppendFormat("Interes de: {0:#.##}", this.Interes);

            return stringBuild.ToString();
        }
        #endregion
    }
}

namespace EntidadFinanciera
{
    public class Financiera
    {
        private List<Prestamo> _listaDePrestamos;
        private string _razonSocial;

        #region "Propiedades"
        public float InteresesEnDolares
        { get { return this.CalcularInteresGanado(TipoDePrestamo.Dolares); } }

        public float InteresesEnPesos
        { get { return this.CalcularInteresGanado(TipoDePrestamo.Pesos); } }

        public float InteresesTotales
        { get { return this.CalcularInteresGanado(TipoDePrestamo.Todos); } }

        public List<Prestamo> ListaDePrestamos
        { get { return this._listaDePrestamos; } }

        public string RazonSocial
        { get { return this._razonSocial; } }
        #endregion

        #region "Constructores"
        private Financiera()
        { this._listaDePrestamos = new List<Prestamo>(); }

        public Financiera(string razonSocial) : this()
        { this._razonSocial = razonSocial; }
        #endregion

        #region "Metodos"
        private float CalcularInteresGanado(TipoDePrestamo tipoPrestamo)
        {
            float retorno = 0;

            foreach (Prestamo prestamoA in this.ListaDePrestamos)
            {
                switch (tipoPrestamo)
                {
                    case TipoDePrestamo.Pesos:
                        {
                            if (prestamoA is PrestamoPesos)
                            { retorno += ((PrestamoPesos)prestamoA).Interes; }
                            break;
                        }
                    case TipoDePrestamo.Dolares:
                        {
                            if (prestamoA is PrestamoDolar)
                            { retorno += ((PrestamoDolar)prestamoA).Interes; }
                            break;
                        }
                    case TipoDePrestamo.Todos:
                        {
                            retorno += (this.CalcularInteresGanado(TipoDePrestamo.Dolares) + this.CalcularInteresGanado(TipoDePrestamo.Pesos));
                            break;
                        }
                    default:
                        break;
                }
            }

            return retorno;
        }

        public static string Mostrar(Financiera financiera)
        { return ((string)financiera); }

        public void OrdenarPrestamos()
        { this._listaDePrestamos.Sort(Prestamo.OrdenarPorFecha); }
        #endregion

        #region "Sobrecargas"
        public static explicit operator String(Financiera financiera)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}\n", financiera.RazonSocial);
            stringBuild.AppendFormat("Intereses Ganados\nTotales: {0}\nPesos: {1}\nDolares: {2}\n", financiera.InteresesTotales, financiera.InteresesEnPesos, financiera.InteresesEnDolares);

            financiera.OrdenarPrestamos();

            foreach (Prestamo prestamoA in financiera.ListaDePrestamos)
            {
                stringBuild.AppendLine("");
                if (prestamoA is PrestamoPesos)
                { stringBuild.AppendLine(((PrestamoPesos)prestamoA).Mostrar()); }
                else if (prestamoA is PrestamoDolar)
                { stringBuild.AppendLine(((PrestamoDolar)prestamoA).Mostrar()); }
            }

            return stringBuild.ToString();
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Financiera financiera, Prestamo prestamo)
        {
            Boolean retorno = false;

            foreach (Prestamo prestamoA in financiera.ListaDePrestamos)
            {
                if (prestamoA == prestamo)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Financiera financiera, Prestamo prestamo)
        {
            return !(financiera == prestamo);
        }

        public static Financiera operator +(Financiera financiera, Prestamo prestamoNuevo)
        {
            if (financiera != prestamoNuevo)
            { financiera._listaDePrestamos.Add(prestamoNuevo); }

            return financiera;
        }
        #endregion
    }
}
