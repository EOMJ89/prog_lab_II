using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesCentralita
{
    public abstract class Llamada
    {
        protected double _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public double Duracion { get { return this._duracion; } }

        public string NroDestino { get { return this._nroDestino; } }

        public string NroOrigen { get { return this._nroOrigen; } }

        public abstract double CostoLlamada { get; }

        public Llamada(string origen, string destino, double duracion)
        {
            this._duracion = duracion;
            this._nroDestino = destino;
            this._nroOrigen = origen;
        }

        protected virtual string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Duracion: {0,10}\n", this.Duracion.ToString());
            stringBuild.AppendFormat("Destino: {0,10}\n", this.NroDestino);
            stringBuild.AppendFormat("Origen: {0,10}\n", this.NroOrigen);

            return stringBuild.ToString();
        }

        public static int OrdernarPorDuracion(Llamada llamadaUno, Llamada llamadaDos)
        {
            int retorno = 0;

            if (llamadaUno.Duracion > llamadaDos.Duracion)
            { retorno = -1; }
            else if (llamadaUno.Duracion < llamadaDos.Duracion)
            { retorno = 1; }

            return retorno;
        }

        public static Boolean operator ==(Llamada llamada1, Llamada llamada2)
        {
            Boolean retorno = false;

            if (llamada1.Equals(llamada2) == true && llamada1.NroOrigen == llamada2.NroOrigen && llamada1.NroDestino == llamada2.NroDestino)
            { retorno = true; }
            return retorno;
        }

        public static Boolean operator !=(Llamada llamada1, Llamada llamada2)
        { return !(llamada1 == llamada2); }
    }

    public class Local : Llamada
    {
        protected double _costo;

        public override double CostoLlamada { get { return this.CalcularCosto(); } }

        public Local(string origen, string destino, double duracion, double costoLocal) : base(origen, destino, duracion)
        { this._costo = costoLocal; }

        protected override string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder(base.Mostrar());
            stringBuild.AppendFormat("Costo: {0,10}\n", this.CostoLlamada.ToString());
            return stringBuild.ToString();
        }

        private double CalcularCosto()
        { return this._costo * base._duracion; }

        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Local)
            {
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }

    public class Provincial : Llamada
    {
        protected EFranja _franjaHoraria;

        public override double CostoLlamada { get { return this.CalcularCosto(); } }

        public Provincial(string origen, string destino, double duracion, EFranja franjaHoraria) : base(origen, destino, duracion)
        { this._franjaHoraria = franjaHoraria; }

        protected override string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder(base.Mostrar());
            stringBuild.AppendFormat("Franja: {0,10}\n", this._franjaHoraria.ToString());
            return stringBuild.ToString();
        }

        private double CalcularCosto()
        {
            double retorno = 0;

            switch (this._franjaHoraria)
            {
                case EFranja.Franja_1:
                    {
                        retorno = 0.99 * base.Duracion;
                        break;
                    }
                case EFranja.Franja_2:
                    {
                        retorno = 1.25 * base.Duracion;
                        break;
                    }
                case EFranja.Franja_3:
                    {
                        retorno = 0.66 * base.Duracion;
                        break;
                    }
                default:
                    { break; }
            }

            return retorno;
        }

        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Provincial)
            {
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }

    public class Centralita
    {
        public List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;

        public Double GananciaPorTotal
        { get { return this.CalcularGanancia(ETipoLlamada.Todas); } }

        public Double GananciaPorLocal
        { get { return this.CalcularGanancia(ETipoLlamada.Local); } }

        public Double GananciaPorProvincial
        { get { return this.CalcularGanancia(ETipoLlamada.Provincial); } }

        private Centralita()
        { this._listaDeLlamadas = new List<Llamada>(); }

        public Centralita(string razonSocial) : this()
        { this._razonSocial = razonSocial; }

        public double CalcularGanancia(ETipoLlamada tipollamada)
        {
            double retorno = 0;
            double recaudacionLocal = 0, recaudacionProvincial = 0;

            foreach (Llamada llamadaA in this._listaDeLlamadas)
            {
                if (llamadaA is Local)
                { recaudacionLocal += ((Local)llamadaA).CostoLlamada; }
                else if (llamadaA is Provincial)
                { recaudacionLocal += ((Provincial)llamadaA).CostoLlamada; }
            }

            switch (tipollamada)
            {
                case ETipoLlamada.Local:
                    {
                        retorno = recaudacionLocal;
                        break;
                    }
                case ETipoLlamada.Provincial:
                    {
                        retorno = recaudacionProvincial;
                        break;
                    }
                case ETipoLlamada.Todas:
                    {
                        retorno = recaudacionLocal + recaudacionProvincial;
                        break;
                    }
                default:
                    break;
            }

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendLine(this._razonSocial);
            stringBuild.AppendLine(this.CalcularGanancia(ETipoLlamada.Todas).ToString());

            foreach (Llamada llamadaA in this._listaDeLlamadas)
            {
                stringBuild.AppendLine(llamadaA.ToString());
            }

            return stringBuild.ToString();
        }

        private void AgregarLlamada(Llamada llamada1)
        { this._listaDeLlamadas.Add(llamada1); }

        public static Boolean operator ==(Centralita centralita1, Llamada llamada1)
        {
            Boolean retorno = false;

            foreach (Llamada llamadaA in centralita1._listaDeLlamadas)
            {
                if (llamadaA == llamada1)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Centralita centralita1, Llamada llamada1)
        { return !(centralita1 == llamada1); }

        public static Centralita operator +(Centralita centralita1, Llamada llamada1)
        {
            if (centralita1 != llamada1)
            { centralita1.AgregarLlamada(llamada1); }

            return centralita1;
        }
    }
}

