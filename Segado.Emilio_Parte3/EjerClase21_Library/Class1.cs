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
                SqlDataReader dataReaderSQL = comandosSQL.ExecuteReader(); //No tiene constructor accesible, solo puede asignarse por este comando, ExecuteReader ejecuta el comando que estaba en el parametro al instanciarl*/

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

        public Boolean Agregar()
        {
            Boolean retorno = false;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion); //Se instancia el SqlConnection para poder utilizar la base
            try
            {
                connectionSQL.Open(); //Se abre la conexción con la base

                SqlCommand comandosSQL = new SqlCommand("INSERT into [Padron].[dbo].[Personas]([nombre],[apellido],[edad]) VALUES ('" + this.Nombre + "','" + this.Apellido + "'," + this.Edad + ")", connectionSQL); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para agregar algo, no para traer, si el atributo es de tipo string, requiere '' y "".
                int registrosAfectados = comandosSQL.ExecuteNonQuery(); //Ejecutar algo que no es una consulta, devuelve la cantidad de registros afectados

                if (registrosAfectados > 0)
                {/*Se deben cerrar ambas conexiones o habrà problema al intentar volver a leerlos*/
                 //Luego la conexión con la base de datos
                    retorno = true;
                }
            }
            catch (Exception e) { }
            finally { connectionSQL.Close(); }
            return retorno;
        }

        public static Boolean Borrar(Persona persona1)
        {
            Boolean retorno = false;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion); //Se instancia el SqlConnection para poder utilizar la base

            try
            {
                connectionSQL.Open(); //Se abre la conexción con la base

                SqlCommand comandosSQL = new SqlCommand("DELETE FROM [Padron].[dbo].[Personas] WHERE [id] = " + persona1.Id, connectionSQL); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para borrar datos
                /*DELETE borra todo el registro completo, sin importar el campo. De no tener con condicion WHERE, borra TODA LA BASE*/

                int registrosAfectados = comandosSQL.ExecuteNonQuery();
                //Console.WriteLine("RegistrosAfectados: {0}", registrosAfectados);

                if (registrosAfectados > 0)
                { retorno = true; }
            }
            catch (Exception e) { }
            finally { connectionSQL.Close(); }
            return retorno;
        }

        public Boolean Modificar()
        {
            Boolean retorno = false;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion); //Se instancia el SqlConnection para poder utilizar la base

            try
            {
                connectionSQL.Open(); //Se abre la conexción con la base

                SqlCommand comandosSQL = new SqlCommand("UPDATE [Padron].[dbo].[Personas] SET [nombre] = '" + this.Nombre + "', [apellido] = '" + this.Apellido + "' , [edad] = " + this.Edad + " WHERE [id] = 15", connectionSQL); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para actualizar datos
                /*UPDATE cambia datos del registro, SET es quien hace los cambios. De nuevo, sin la condición, va a cambiar TODOS LOS REGISTROS DE LA BASE*/

                int registrosAfectados = comandosSQL.ExecuteNonQuery();
                //Console.WriteLine("RegistrosAfectados: {0}", registrosAfectados);

                if (registrosAfectados > 0) { retorno = true; }
            }
            catch (Exception e) { }
            finally { connectionSQL.Close(); }
            return retorno;
        }

        public static Persona TraerTodos(int id) //Version de 1 parametro, traer la persona con el ID pasado por parametro.
        {
            Persona retorno = null;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion);

            try
            {
                connectionSQL.Open();

                SqlCommand comandosSQL = new SqlCommand("SELECT * [id],[nombre],[apellido],[edad] FROM [Padron].[dbo].[Personas] WHERE [id] = " + id, connectionSQL); //Selecciona todo los registros que cumplen con la condición pedida, puede ser uno, muchos o ninguno
                SqlDataReader dataReaderSQL = comandosSQL.ExecuteReader();

                while (dataReaderSQL.Read())
                { retorno = new Persona(((int)dataReaderSQL["id"]), dataReaderSQL["nombre"].ToString(), dataReaderSQL["apellido"].ToString(), ((int)dataReaderSQL["edad"])); }

                dataReaderSQL.Close();
            }
            catch (Exception e) { }
            finally { connectionSQL.Close(); }

            return retorno;
        }

        public static DataTable TraerTodosTabla()
        {
            DataTable tablaRetorno = new DataTable("Personas"); //Permite tener una base de datos en memoria, sin depender del servidor de base de datos
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion);

            try
            {
                connectionSQL.Open();

                SqlCommand comandosSQL = new SqlCommand("SELECT [id],[nombre],[apellido],[edad] FROM [Padron].[dbo].[Personas]", connectionSQL); //Se traen todos los registros, al igual que con la lista de personas
                SqlDataReader dataReaderSQL = comandosSQL.ExecuteReader();

                tablaRetorno.Load(dataReaderSQL); //Esto hace todo el proceso automatico de trasladar lo obtenido del DataReader al DataTable

                dataReaderSQL.Close(); //Primero el SqlDataReader                
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { connectionSQL.Close(); }

            return tablaRetorno;
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
