﻿using System;
using System.Collections.Generic;
using System.IO; //Para utilizar StreamWriter
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary; //Para utilizar BinaryFormatter
using System.Xml; //Para utilizar XmlTextWriter
using System.Xml.Serialization; //Para usar XmlSerializer

namespace EjerClase19_Library
{
    [Serializable]
    public class Jugador : ISerializableBinario, ISerializableXML
    {
        protected string _nombre;
        public string _apellido;
        protected EPuesto _puesto;

        #region "Propiedades de solo lectura"
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }

        public string Apellido { get { return this._apellido; } }

        public EPuesto Puesto { get { return this._puesto; } }
        #endregion

        #region "Constructor"
        public Jugador(string nombre, string apellido, EPuesto puesto)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._puesto = puesto;
        }

        public Jugador() : this("A", "B", EPuesto.Delantero) { }
        #endregion

        #region "Metodos"
        public static Boolean TraerUno(string path, Jugador jugadorA, out Jugador jugadorRetorno)
        {
            Boolean retorno = false;
            string readText = "";
            jugadorRetorno = null;

            if (AdministradorDeArchivos.Leer(path, out readText) == true)
            {
                string[] auxArrayNombres = readText.Split('\n'); //Separa los elementos mediante el caracter de separacion

                foreach (string itemA in auxArrayNombres)
                {
                    string[] auxJugadorDatos = itemA.Split('-'); //Index 0 = Nombre, Index 1 = Apellido, Index 2 = Puesto
                    if (jugadorA.Nombre == auxJugadorDatos[0] && jugadorA.Apellido == auxJugadorDatos[1] && jugadorA.Puesto.ToString() == auxJugadorDatos[2].Trim()) //el auxJugadorDatos[2] necesita el trim debido a que al escribir, se añade tambien un '/r' ademas del '/n'.
                    {
                        jugadorRetorno = new Jugador(auxJugadorDatos[0], auxJugadorDatos[1], ((EPuesto)Enum.Parse(typeof(EPuesto), auxJugadorDatos[2].Trim()))); //Enum.Parse devuelve un object, debe castearse para que funcione correctamente.
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{1}-{2}", this.Nombre, this.Apellido, this.Puesto);
            return stringBuild.ToString(); ;
        }
        #endregion

        #region "Enumerados"
        public enum EPuesto
        { Arquero, Defensa, Medio, Delantero }
        #endregion

        void ISerializableBinario.Serializar()
        {
            BinaryFormatter formatter = new BinaryFormatter(); //Se encarga de formatear, con serialize y deserialize
            FileStream fileStream = new FileStream(@"jugadores.dat", FileMode.Create);//nos permite manejar todo tipo de archivos: Necesita Path en formato string y Enumerado que indica la forma de tratar el archivo (crear, tratar y abrir, agregar) con FileMode

            formatter.Serialize(fileStream, this); //Recibe el FileStream que ya posee el path y el modo de tratar archivos
            fileStream.Close();
        }

        Jugador ISerializableBinario.Deserializar()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(@"jugadores.dat", FileMode.Open);

            Jugador retorno = ((Jugador)formatter.Deserialize(fileStream)); //Devuelve un object que debe ser casteado
            fileStream.Close();
            return retorno;
        }

        void ISerializableXML.Serializar()
        {
            XmlTextWriter fileEncoding = new XmlTextWriter(@"jugadores.xml", Encoding.UTF8); 
            XmlSerializer serializerXml = new XmlSerializer(typeof(Jugador)); 

            serializerXml.Serialize(fileEncoding, this);
            fileEncoding.Close();
        }

        Jugador ISerializableXML.Deserializar()
        {
            XmlTextReader fileDecoding = new XmlTextReader(@"jugadores.xml");
            XmlSerializer serializerXml = new XmlSerializer(typeof(Jugador));

            Jugador retorno = ((Jugador)serializerXml.Deserialize(fileDecoding));
            fileDecoding.Close();
            return retorno;
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

    public interface ISerializableBinario
    {
        void Serializar();
        Jugador Deserializar();
    }

    public interface ISerializableXML
    {
        void Serializar();
        Jugador Deserializar();
    }
}
