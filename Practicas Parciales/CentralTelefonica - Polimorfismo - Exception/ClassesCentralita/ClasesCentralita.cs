using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace ClassesCentralita
{
    public interface IGuardar<T>
    {
        string RutaDeArchivos { get; set; }

        Boolean Guardar();

        T Leer();
    }

    [Serializable]
    [XmlInclude(typeof(Local))]
    [XmlInclude(typeof(Provincial))]
    public abstract class Llamada
    {
        protected double _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public double Duracion { get { return this._duracion; } set { this._duracion = value; } }

        public string NroDestino { get { return this._nroDestino; } set { this._nroDestino = value; } }

        public string NroOrigen { get { return this._nroOrigen; } set { this._nroOrigen = value; } }

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

    [Serializable]
    public class Local : Llamada, IGuardar<Local>
    {
        protected double _costo;
        protected string _ruta;

        public override double CostoLlamada { get { return this.CalcularCosto(); } }

        public double Costo { get { return this._costo; } set { this._costo = value; } }

        string IGuardar<Local>.RutaDeArchivos { get { return this._ruta; } set { this._ruta = value; } }

        public Local(string origen, string destino, double duracion, double costoLocal) : base(origen, destino, duracion)
        { this._costo = costoLocal; }

        public Local() : this("", "", 0, 0) { }

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
            Boolean retorno = false;

            XmlTextWriter fileEncoding = new XmlTextWriter(((IGuardar<Local>)this).RutaDeArchivos, Encoding.UTF8); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(Local)); //Para el tipo de objeto que se quiere serializar

            try
            {
                serializerXml.Serialize(fileEncoding, new Local(this._nroOrigen,this._nroDestino,this._duracion, this._costo)); /*Se para el archivo que escribe (XmlTextWriter) y el objeto a serializar*/
                retorno = true;
            }
            catch (Exception e) { }

            fileEncoding.Close();
            return retorno;
        }

        Local IGuardar<Local>.Leer()
        {
            Local retorno = new Local("a", "b", 0, 0);
            XmlTextReader filePath = new XmlTextReader(((IGuardar<Local>)this).RutaDeArchivos); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(Local));

            try
            {
                retorno = ((Local)serializerXml.Deserialize(filePath));
            }
            catch (Exception e) { }
            filePath.Close();

            return retorno;
        }
    }

    [Serializable]
    public class Provincial : Llamada, IGuardar<Provincial>
    {
        protected EFranja _franjaHoraria;
        private string _ruta;

        public override double CostoLlamada { get { return this.CalcularCosto(); } }

        public EFranja FranjaHoraria { get { return this._franjaHoraria; } set { this._franjaHoraria = value; } }

        string IGuardar<Provincial>.RutaDeArchivos { get {return this._ruta; } set { this._ruta = value; } }

        public Provincial(string origen, string destino, double duracion, EFranja franjaHoraria) : base(origen, destino, duracion)
        { this._franjaHoraria = franjaHoraria; }

        public Provincial() : this("", "", 0, EFranja.Franja_1) { }

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
            Boolean retorno = false;

            XmlTextWriter fileEncoding = new XmlTextWriter(((IGuardar<Provincial>)this).RutaDeArchivos, Encoding.UTF8); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(Provincial)); //Para el tipo de objeto que se quiere serializar

            try
            {
                serializerXml.Serialize(fileEncoding, this); /*Se para el archivo que escribe (XmlTextWriter) y el objeto a serializar*/
                retorno = true;
            }
            catch (Exception e) { }

            fileEncoding.Close();
            return retorno;
        }

        Provincial IGuardar<Provincial>.Leer()
        {
            Provincial retorno = new Provincial("a", "b", 0, 0);
            XmlTextReader filePath = new XmlTextReader(((IGuardar<Provincial>)this).RutaDeArchivos); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(Provincial));

            try
            {
                retorno = ((Provincial)serializerXml.Deserialize(filePath));
            }
            catch (Exception e) { }
            filePath.Close();

            return retorno;
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

            for (int i = 2; i < lineas.Length - 2; i++)
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
            if (innerException is CentralitaException)
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

