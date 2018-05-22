using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio30_Library
{
    public class AutoF1
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

        public AutoF1(Int16 numero, string escuderia)
        {
            this.CantidadCombustible = 0;
            this.EnCompetencia = false;
            this._escuderia = escuderia;
            this._numero = numero;
            this.VueltasRestantes = 0;
        }

        public string MostrarDatos()
        {
            StringBuilder stringBuild = new StringBuilder();

            stringBuild.AppendFormat("AUTO N°{0}.\n", this._numero);
            stringBuild.AppendFormat("Escudería: {0}.\n", this._escuderia);
            stringBuild.AppendFormat("En Competencia: {0}.\n", this.EnCompetencia);
            stringBuild.AppendFormat("Tiene {0} litros de Combustible.\n", this.CantidadCombustible);
            stringBuild.AppendFormat("Vueltas restantes: {0}.\n", this.VueltasRestantes);

            return stringBuild.ToString();
        }

        public static Boolean operator ==(AutoF1 a1, AutoF1 a2)
        {
            Boolean retorno = false;

            if (a1._numero == a2._numero && a1._escuderia == a2._escuderia)
            { retorno = true; }
            return retorno;
        }

        public static Boolean operator !=(AutoF1 a1, AutoF1 a2)
        {
            return !(a1 == a2);
        }
    }

    public class Competencia
    {
        private Int16 _cantidadCompetidores;
        private Int16 _cantidadVueltas;
        private List<AutoF1> _competidores;

        #region Constructores
        private Competencia()
        { this._competidores = new List<AutoF1>(); }

        public Competencia(Int16 cantidadVueltas, Int16 cantidadCompetidores) : this()
        {
            this._cantidadCompetidores = cantidadCompetidores;
            this._cantidadVueltas = cantidadVueltas;
        }
        #endregion

        public static Boolean operator +(Competencia c, AutoF1 a)
        {
            Boolean retorno = false;
            Random combustible = new Random();

            if (c._cantidadCompetidores > c._competidores.Count)
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

            return retorno;
        }

        public static Boolean operator -(Competencia c, AutoF1 a)
        {
            Boolean retorno = false;

            if (c == a)
            {
                c._competidores.Remove(a);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator ==(Competencia c, AutoF1 a)
        {
            Boolean retorno = false;

            foreach (AutoF1 autoA in c._competidores)
            {
                if (autoA == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static Boolean operator !=(Competencia c, AutoF1 a)
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

            foreach (AutoF1 autoA in this._competidores)
            { stringBuild.AppendLine(autoA.MostrarDatos()); }

            return stringBuild.ToString();
        }
    }
}
