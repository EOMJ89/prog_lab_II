using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassesCentralita
{
    public interface IGuardar<T>
    {
        string RutaDeArchivos { get; set; }

        Boolean Guardar();

        T Leer();
    }

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
            stringBuild.AppendFormat("{0}-", this.Duracion.ToString());
            stringBuild.AppendFormat("{0}-", this.NroDestino);
            stringBuild.AppendFormat("{0}", this.NroOrigen);

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

    public class Local : Llamada, IGuardar<Local>
    {
        protected double _costo;

        public override double CostoLlamada { get { return this.CalcularCosto(); } }

        string IGuardar<Local>.RutaDeArchivos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Local(string origen, string destino, double duracion, double costoLocal) : base(origen, destino, duracion)
        { this._costo = costoLocal; }

        protected override string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder(base.Mostrar());
            stringBuild.AppendFormat("-{0}", this.CostoLlamada.ToString());
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

        bool IGuardar<Local>.Guardar()
        {
            throw new NotImplementedException();
        }

        Local IGuardar<Local>.Leer()
        {
            throw new NotImplementedException();
        }
    }

    public class Provincial : Llamada, IGuardar<Provincial>
    {
        protected EFranja _franjaHoraria;

        public override double CostoLlamada { get { return this.CalcularCosto(); } }

        string IGuardar<Provincial>.RutaDeArchivos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Provincial(string origen, string destino, double duracion, EFranja franjaHoraria) : base(origen, destino, duracion)
        { this._franjaHoraria = franjaHoraria; }

        protected override string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder(base.Mostrar());
            stringBuild.AppendFormat("-{0}", this._franjaHoraria.ToString());
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

        bool IGuardar<Provincial>.Guardar()
        {
            throw new NotImplementedException();
        }

        Provincial IGuardar<Provincial>.Leer()
        {
            throw new NotImplementedException();
        }
    }

    public class Centralita : IGuardar<Centralita>
    {
        public List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;
        private string _ruta;

        public Double GananciaPorTotal
        { get { return this.CalcularGanancia(ETipoLlamada.Todas); } }

        public Double GananciaPorLocal
        { get { return this.CalcularGanancia(ETipoLlamada.Local); } }

        public Double GananciaPorProvincial
        { get { return this.CalcularGanancia(ETipoLlamada.Provincial); } }

        string IGuardar<Centralita>.RutaDeArchivos { get { return this._ruta; } set { this._ruta = value; } }

        private Centralita()
        { this._listaDeLlamadas = new List<Llamada>(); }

        public Centralita(string razonSocial) : 
            this()
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

        bool IGuardar<Centralita>.Guardar()
        {
            return AdministradorDeArchivos.Escribir(((IGuardar<Centralita>)this).RutaDeArchivos, this.ToString(), false);
        }

        Centralita IGuardar<Centralita>.Leer()
        {
            string datos = "";
            AdministradorDeArchivos.Leer(((IGuardar<Centralita>)this).RutaDeArchivos, out datos);

            string[] lineas = datos.Split('\n');

            Centralita retorno = new Centralita();
            retorno._razonSocial = lineas[0].Trim();

            for (int i = 2; i < lineas.Length-2; i++)
            {
                string[] datosLinea = lineas[i].Split('-');

                if (((datosLinea[3].Trim()).Contains("Franja_1") || (datosLinea[3].Trim()).Contains("Franja_2") || (datosLinea[3].Trim()).Contains("Franja_3")))
                { retorno += new Provincial(datosLinea[2], datosLinea[1], double.Parse(datosLinea[0]), ((EFranja)Enum.Parse(typeof(EFranja), datosLinea[3].Trim()))); }
                else
                { retorno += new Local(datosLinea[2], datosLinea[1], double.Parse(datosLinea[0]), double.Parse(datosLinea[3].Trim())); }
            }

            return retorno;
        }

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
            else
            {
                string typeLlamada = "";
                if (llamada1 is Provincial)
                { typeLlamada = "Pronvicial"; }
                else
                { typeLlamada = "Local"; }

                throw new CentralitaException("La llamada ya está en la lista", typeLlamada, "Operador + de centralita");
            }

            return centralita1;
        }
    }

    public class CentralitaException : Exception
    {
        private string _nombreClase;
        private string _nombreMetodo;

        public Exception ExceptionInterna { get { return base.InnerException; } }

        public string NombreClase { get { return this._nombreClase; } }

        public string NombreMetodo { get { return this._nombreMetodo; } }

        public CentralitaException(String mensaje, String nombreClase, String nombreMetodo) : base(mensaje)
        {
            this._nombreMetodo = nombreMetodo;
            this._nombreClase = nombreClase;
        }

        public CentralitaException(String mensaje, String nombreClase, String nombreMetodo, Exception innerException) : base(mensaje, innerException)
        {
            if(innerException is CentralitaException)
	    {
		this._nombreMetodo = ((CentralitaException)innerException)._nombreMetodo;
       		this._nombreClase = ((CentralitaException)innerException)._nombreClase;
	    }
        }
    }

    public static class AdministradorDeArchivos
    {
        public static Boolean Escribir(string path, string whatToWrite, bool appendOrOverwrite)
        {
            Boolean retorno = false;
            StreamWriter auxGuardado;

            if ((auxGuardado = new StreamWriter(path, appendOrOverwrite)) != null)
            {
                auxGuardado.WriteLine(whatToWrite);
                retorno = true;
            }
            auxGuardado.Close();

            return retorno;
        }

        public static Boolean Leer(string path, out string readText)
        {
            Boolean retorno = false;

            StreamReader auxLectura = new StreamReader(path);
            if ((readText = auxLectura.ReadToEnd()) != null)
            { retorno = true; }
            auxLectura.Close();
            return retorno;
        }
    }
}

