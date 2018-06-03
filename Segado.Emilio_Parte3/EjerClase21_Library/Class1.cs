using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Requerido para base de datos
using System.Data.SqlClient;  //Requerido para la comunicacion con SQL

namespace EjerClase21_Library
{
    public class Persona
    {
        private string _nombre;
        private string _apellido;
        private int _edad;
        private int _id;

        #region "Propiedades"
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int Edad
        {
            get { return this._edad; }
            set { this._edad = value; }
        }

        public int Id
        { get { return this._id; } }
        #endregion

        #region "Constructores"
        public Persona(string nombre, string apellido, int edad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Edad = edad;
        }

        public Persona(int id, string nombre, string apellido, int edad)
            : this(nombre, apellido, edad)
        { this._id = id; }
        #endregion

        #region "Métodos"
        public static List<Persona> TraerTodos()
        {
            List<Persona> listaRetorno = new List<Persona>();

            try
            {
                SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion); //requiere string de collecion, que tiene ciertos parametros para hacer la conexión, eso es una serie de caracteres a modo de cadena con permisos, etc.
                /*Properties.Settings.Default.conexion permite acceder a las propiedades del proyecto y la aplicacion*/

                connectionSQL.Open(); //Esto requiere el objeto instanciado, abre la conexion a la base de datos
                /*A partir de aqui se debe usar el lenguaje de SQL*/
                SqlCommand comandosSQL = new SqlCommand("SELECT [id],[nombre],[apellido],[edad] FROM [Padron].[dbo].[Personas]", connectionSQL); //Pide string a ejecutar (los comandos de consulta de SQL en modo de cadena) y el objeto de conexion
                SqlDataReader dataReaderSQL = comandosSQL.ExecuteReader(); //No tiene constructor accesible, solo puede asignarse por este comando, ExecuteReader ejecuta el comando que estaba en el parametro al instanciarlo


                while (dataReaderSQL.Read()) //Mientras el dataReader tenga objetos para leer
                {
                    //string string1 = dataReaderSQL[0].ToString(); /*el [0] es el orden de cambios EN LA CONSULTA, esto retorna un object encapsulado, debido a que pueden variar los tipos. Esto es un array indexado*/
                    //int id = ((int)dataReaderSQL["id"]); /*Array asociativo de SQL*/          
                    listaRetorno.Add(new Persona(((int)dataReaderSQL["id"]), dataReaderSQL["nombre"].ToString(), dataReaderSQL["apellido"].ToString(), ((int)dataReaderSQL["edad"]))); //Por cada objeto leido, añadelo a la lista, utilizando como parametros lo obtenido del dataReader y casteado a su respectivo tipo
                }

                /*Se deben cerrar ambas conexiones o habrà problema al intentar volver a leerlos*/
                dataReaderSQL.Close(); //Primero el SqlDataReader
                connectionSQL.Close(); //Luego la conexión con la base de datos
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return listaRetorno;
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        {
            return this.Id + "-" + this.Nombre + "-" + this.Apellido + "-" + this.Edad;
        }
        #endregion
    }
}
