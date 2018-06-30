﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public interface ISerializable
    {
        string RutaArchivo
        { get; set; }

        Boolean Deserializar();

        Boolean Serializar();
    }

    public abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        #region "Propiedades"
        public abstract Boolean TieneCarozo
        { get; }
        #endregion

        #region "Constructores"
        public Fruta(float peso, ConsoleColor color)
        {
            this._color = color;
            this._peso = peso;
        }
        #endregion

        #region "Métodos"
        protected virtual string FrutaToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{1}", this._color, this._peso);

            return stringBuild.ToString();
        }
        #endregion
    }

    [Serializable]
    public class Platano : Fruta
    {
        public string _paisOrigen;

        #region "Propiedades"
        public override bool TieneCarozo
        { get { return false; } }

        public string Tipo
        { get { return "Plátano"; } }
        #endregion

        #region "Constructores"
        public Platano() : base(0, ConsoleColor.White) { }

        public Platano(float peso, ConsoleColor color, string pais)
            : base(peso, color)
        { this._paisOrigen = pais; }
        #endregion

        #region "Métodos"
        protected override string FrutaToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{2}-{1}", this.Tipo, this._paisOrigen, base.FrutaToString());

            return stringBuild.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        { return this.FrutaToString(); }
        #endregion
    }

    [Serializable]
    public class Manzana : Fruta, ISerializable
    {
        public string _distribuidora;

        #region "Propiedades"
        public override bool TieneCarozo
        { get { return true; } }

        public string Tipo
        { get { return "Manzana"; } }
        #endregion

        #region "Constructores"
        public Manzana() : base(0, ConsoleColor.White) { }

        public Manzana(float peso, ConsoleColor color, string distribuidora) : base(peso, color)
        { this._distribuidora = distribuidora; }
        #endregion

        #region "Métodos"
        #region "Implementacion de ISerializable"
        public string RutaArchivo
        { get; set; }

        public bool Deserializar()
        {
            Boolean retorno = false;
            XmlTextReader filePath = new XmlTextReader(this.RutaArchivo);
            XmlSerializer serializerXml = new XmlSerializer(typeof(Manzana));

            try
            {
                Manzana auxManzana = ((Manzana)serializerXml.Deserialize(filePath));

                //Se asignan los atributos principales del auxiliar a la instancia
                this._color = auxManzana._color;
                this._distribuidora = auxManzana._distribuidora;
                this._peso = auxManzana._peso;
                this.RutaArchivo = auxManzana.RutaArchivo;

                retorno = true;
            }
            catch (Exception e) { }
            finally
            { filePath.Close(); }

            return retorno;
        }

        public bool Serializar()
        {
            Boolean retorno = false;
            XmlTextWriter fileEncoding = new XmlTextWriter(((ISerializable)this).RutaArchivo, Encoding.UTF8);
            XmlSerializer serializerXml = new XmlSerializer(typeof(Manzana));

            try
            {
                serializerXml.Serialize(fileEncoding, this);
                retorno = true;
            }
            catch (Exception e) { }
            finally
            { fileEncoding.Close(); }

            return retorno;
        }
        #endregion

        protected override string FrutaToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{2}-{1}", this.Tipo, this._distribuidora, base.FrutaToString());

            return stringBuild.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        { return this.FrutaToString(); }
        #endregion
    }

    [Serializable]
    [XmlInclude(typeof(Manzana))]
    [XmlInclude(typeof(Platano))]
    public class Cajon<T> : ISerializable
    {
        protected List<T> _frutas;
        protected int _capacidad;
        protected float _precioUnitario;

        #region "Propiedades"
        public List<T> Frutas
        { get { return this._frutas; } }

        public float PrecioTotal
        {
            get
            {
                float totalPrecio = this.CalcularPrecioCajon();

                if (totalPrecio > 25)
                { this.EventoPrecio.Invoke(this, new EventArgs()); }

                return totalPrecio;
            }
        }
        #endregion

        #region "Constructores"
        public Cajon()
        {
            this._frutas = new List<T>();
            this.EventoPrecio += new CajonDelegado(this.GuardarArchivo);
        }

        public Cajon(int capacidad) : this()
        { this._capacidad = capacidad; }

        public Cajon(int capacidad, float precio) : this(capacidad)
        { this._precioUnitario = precio; }
        #endregion

        #region "Métodos"
        #region "Implementacion de ISerializable"
        public string RutaArchivo
        { get; set; }

        public bool Deserializar()
        {
            Boolean retorno = false;
            XmlTextReader filePath = new XmlTextReader(this.RutaArchivo);
            XmlSerializer serializerXml = new XmlSerializer(typeof(Cajon<T>));

            try
            {
                Cajon<T> auxCajon = ((Cajon<T>)serializerXml.Deserialize(filePath));

                //Se asignan los atributos principales del auxiliar a la instancia
                this._capacidad = auxCajon._capacidad;
                this._frutas = auxCajon.Frutas;
                this._precioUnitario = auxCajon._precioUnitario;
                this.RutaArchivo = auxCajon.RutaArchivo;

                retorno = true;
            }
            catch (Exception e) { }
            finally
            { filePath.Close(); }

            return retorno;
        }

        public bool Serializar()
        {
            Boolean retorno = false;
            XmlTextWriter fileEncoding = new XmlTextWriter(this.RutaArchivo, Encoding.UTF8);
            XmlSerializer serializerXml = new XmlSerializer(typeof(Cajon<T>));

            try
            {
                serializerXml.Serialize(fileEncoding, this);
                retorno = true;
            }
            catch (Exception e)
            { /*Console.WriteLine(e.Message);*/ }
            finally
            { fileEncoding.Close(); }

            return retorno;
        }
        #endregion

        private float CalcularPrecioCajon()
        {
            float retorno = 0;

            foreach (T frutaA in this._frutas)
            { retorno += this._precioUnitario; }

            return retorno;
        }

        public static Cajon<T> operator +(Cajon<T> c, T f)
        {
            Cajon<T> cajonAux = c;

            if (cajonAux._frutas.Count < cajonAux._capacidad)
            { cajonAux._frutas.Add(f); }
            else
            { throw new CajonLlenoException("El cajón se encuentra lleno."); }

            return cajonAux;
        }

        private string MostrarCajon()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad del Cajón: {0}\n", this._capacidad);
            stringBuild.AppendFormat("Cantidad de frutas en el Cajón: {0}\n", this._frutas.Count);
            stringBuild.AppendFormat("Precio total del Cajón: {0}\n", this.CalcularPrecioCajon());

            foreach (T frutaA in this._frutas)
            { stringBuild.AppendLine(frutaA.ToString()); }

            return stringBuild.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        { return this.MostrarCajon(); }
        #endregion

        #region "Evento"
        public event CajonDelegado EventoPrecio;
        #endregion

        #region "Delegado para Cajon"
        public delegate void CajonDelegado(Cajon<T> elemento, EventArgs e);
        #endregion

        #region "Manejador"
        private void GuardarArchivo(Cajon<T> elemento, EventArgs e)
        {
            StreamWriter auxWriter;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\bitacoraCajon.txt";

            if ((auxWriter = new StreamWriter(path, true)) != null)
            {
                string auxTexto = DateTime.Now.ToString() + " Precio de Cajón: " + elemento.CalcularPrecioCajon();

                auxWriter.WriteLine(auxTexto);
            }

            auxWriter.Close();

        }
        #endregion
    }
}
