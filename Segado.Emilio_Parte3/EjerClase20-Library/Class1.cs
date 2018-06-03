using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace EjerClase20_Library
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))] //Si hay más clases heredas, de las clases ya heredaas, la clase base solo tiene a sus hijos directos, luego cada hijo tiene a su "nieto" correspondiente.
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;
        protected int _dni;

        public Persona(string nombre, string apellido, int dni)
        {
            this._apellido = apellido;
            this._dni = dni;
            this._nombre = nombre;
        }

        public override string ToString()
        {
            return this._nombre + "-" + this._apellido + "-" + this._dni;
        }
    }

    [Serializable]
    public class Alumno : Persona
    {
        public int _legajo;

        public Alumno(string nombre, string apellido, int dni, int legajo)
            : base(nombre, apellido, dni)
        { this._legajo = legajo; }

        public Alumno() : this("", "", 0, 0) { }

        public override string ToString()
        { return base.ToString() + "-" + this._legajo; }
    }

    [Serializable]
    public class Profesor : Persona
    {
        public string _titulo;

        public Profesor(string nombre, string apellido, int dni, string titulo)
            : base(nombre, apellido, dni)
        { this._titulo = titulo; }

        public Profesor() : this("", "", 0,"") { }

        public override string ToString()
        { return base.ToString() + "-" + this._titulo; }
    }

    public class Aula
    {
        private int _numero;
        private List<Persona> _lista;

        public List<Persona> Lista
        { get { return this._lista; } }

        public int Numero
        {
            get { return this._numero; }
            set { this._numero = value; }
        }

        public Aula(int numero)
            : this()
        { this._numero = numero; }

        public Aula()
        { this._lista = new List<Persona>(); }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendLine(this.Numero.ToString());

            foreach (Persona personaA in this._lista)
            {
                if (personaA is Alumno)
                { stringBuild.AppendLine(((Alumno)personaA).ToString()); }
                else if (personaA is Profesor)
                { stringBuild.AppendLine(((Profesor)personaA).ToString()); }
            }

            return stringBuild.ToString();
        }
    }

    public class XML<T>
    {
        public Boolean GuardarXML(string path, T alumnoAGuardar)
        {
            Boolean retorno = false;

            XmlTextWriter fileEncoding = new XmlTextWriter(path, Encoding.UTF8); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(T)); //Para el tipo de objeto que se quiere serializar

            try
            {
                serializerXml.Serialize(fileEncoding, alumnoAGuardar); /*Se para el archivo que escribe (XmlTextWriter) y el objeto a serializar*/
                retorno = true;
            }
            catch (Exception e) { }

            fileEncoding.Close();
            return retorno;
        }

        public bool LeerXML(string path, out T aRecuperar)
        {
            Boolean retorno = false;
            aRecuperar = default(T);
            XmlTextReader filePath = new XmlTextReader(path); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(T));

            try
            {
                aRecuperar = ((T)serializerXml.Deserialize(filePath));
                retorno = true;
            }
            catch (Exception e)
            { }
            filePath.Close();
            return retorno;
        }
    }
}
