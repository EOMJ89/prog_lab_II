using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Entidades.Alumnos;
using Entidades.Externa;
using Entidades.Externa.Sellada;
using System.Data;//Requerido para base de datos
using System.Data.SqlClient;  //Requerido para la comunicacion con SQL

namespace EjerClase25
{
    //Opción 4: Metodos de extensión, estos tomarán el primer parametro como la instancia de objecto desde la cual se las invoca (funcionan como metodos de instancia)
    public static class ClaseExtensora
    {
        public static string ObtenerInfo(this Persona p)
        { return p.ToString(); }

        public static string ObtenerInfoExterna(this PersonaExterna p) //No va a funcionar debido a no poder usar sobrecargas en ella
        { return p.ToString(); }

        public static string ObtenerInfoExternaDerivada(this PersonaExternaDerivada p)
        { return p.ToString(); }

        //Aquí se puede ver que debido a ser una clase sellada, la opción 3 no serviria, así que si se tiene acceso a sus propiedades o a algún metodo que la muestre, podria utilizarse para el metodo de extensión
        public static string ObtenerInfoDll(this PersonaExternaSellada p)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{1}-{2}-{3}", p.Nombre, p.Apellido, p.Edad, p.Sexo);

            return stringBuild.ToString();
        }

        //Los metodos de extensión pueden ser simples o complejos, desde mostrar datos hasta guardarlos dentro de archivos o bases de datos
        public static Boolean GuardaArchivo(this Persona p, string path)
        {
            Boolean retorno = false;

            StreamWriter auxGuardado;

            if ((auxGuardado = new StreamWriter(path, true)) != null)
            {
                auxGuardado.WriteLine(p.ToString());
                retorno = true;
            }
            auxGuardado.Close();

            return retorno;
        }

        public static Boolean IsNull(this object o)
        {
            Boolean retorno = false;

            if (o == null)
            { retorno = true; }

            return retorno;
        }

        public static int CantidadCaracteres(this string s)
        { return s.Length; }

        public static Boolean AgregarBD(this PersonaExternaSellada p)
        {
            Boolean retorno = false;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion);

            try
            {
                connectionSQL.Open();

                SqlCommand comandosSQL = new SqlCommand("INSERT into [personasBD].[dbo].[tabla1]([apellido],[nombre],[edad],[sexo]) VALUES ('" + p.Apellido + "','" + p.Nombre + "'," + p.Edad + "," + ((int)p.Sexo) + ")", connectionSQL);

                int registrosAfectados = comandosSQL.ExecuteNonQuery();
                if (registrosAfectados > 0)
                { retorno = true; }
            }
            catch (Exception e) { }
            finally
            { connectionSQL.Close(); }

            return retorno;
        }

        public static Boolean TraerPersonas(this List<PersonaExternaSellada> list)
        {
            Boolean retorno = false;
            SqlCommand comandosSQL;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion);
            list = new List<PersonaExternaSellada>();

            try
            {
                connectionSQL.Open();
                comandosSQL = new SqlCommand("SELECT [id],[apellido],[nombre],[edad],[sexo] FROM [personasBD].[dbo].[tabla1]", connectionSQL);
                SqlDataReader dataReaderSQL = comandosSQL.ExecuteReader();

                while (dataReaderSQL.Read())
                { list.Add(new PersonaExternaSellada(dataReaderSQL["nombre"].ToString().Trim(), dataReaderSQL["apellido"].ToString().Trim(), ((int)dataReaderSQL["edad"]), ((Entidades.Externa.Sellada.ESexo)((int)dataReaderSQL["sexo"])))); }

                dataReaderSQL.Close();
                retorno = true;
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { connectionSQL.Close(); }

            return retorno;
        }
    }
}
