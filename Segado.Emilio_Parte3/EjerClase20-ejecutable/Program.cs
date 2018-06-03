using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase20_Library;
using System.Xml; //Para utilizar XmlTextWriter
using System.Xml.Serialization; //Para usar XmlSerializer

namespace EjerClase20_ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alA = new Alumno("A", "Z", 10, 1000);
            Alumno alB = new Alumno("B", "X", 11, 1001);
            Alumno alC = new Alumno("C", "Y", 12, 1002);
            Profesor profeA = new Profesor("D", "W", 13, "Titulo1");
            Profesor profeB = new Profesor("E", "V", 14, "Titulo2");
            Profesor profeC = new Profesor("F", "U", 15, "Titulo3");
            Aula aula1 = new Aula(10);
            aula1.Lista.Add(alA);
            aula1.Lista.Add(alB);
            aula1.Lista.Add(alC);
            aula1.Lista.Add(profeA);
            aula1.Lista.Add(profeB);
            aula1.Lista.Add(profeC);

            //Console.WriteLine(alA);
            //Console.WriteLine(alB);
            //Console.WriteLine(alC);
            //Console.WriteLine(profeC);
            //Console.WriteLine(profeB);
            //Console.WriteLine(profeC);
            //Console.ReadLine();
            //Console.Clear();


            //Console.WriteLine(aula1.ToString());

            //if (GuardarXML(@"alumno.xml", alA))
            //{ Console.WriteLine("Serializado exitosamente"); }

            //Alumno alZ = new Alumno();

            //if (LeerXML(@"alumno.xml", out alZ))
            //{
            //    Console.WriteLine("Deserializado exitosamente");
            //    Console.WriteLine(alZ.ToString());
            //}

            /*
            XML<Alumno> serializerAlumno = new XML<Alumno>();
            
            if (serializerAlumno.GuardarXML(@"alumno.xml", alA))
            { Console.WriteLine("Serializado exitosamente"); }

            Alumno alZ = new Alumno();

            if (serializerAlumno.LeerXML(@"alumno.xml", out alZ))
            {
                Console.WriteLine("Deserializado exitosamente");
                Console.WriteLine(alZ.ToString());
            }
            Console.WriteLine();

            XML<Profesor> serializerProfesor = new XML<Profesor>();
            if (serializerProfesor.GuardarXML(@"alumno.xml", profeA))
            { Console.WriteLine("Serializado exitosamente"); }

            Profesor profeZ = new Profesor();

            if (serializerProfesor.LeerXML(@"alumno.xml", out profeZ))
            {
                Console.WriteLine("Deserializado exitosamente");
                Console.WriteLine(profeZ.ToString());
            }
            */
            /*XML<List<Alumno>> serializerListaAlumno = new XML<List<Alumno>>();
            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos.Add(alA);
            listaAlumnos.Add(alB);
            listaAlumnos.Add(alC);

            if (serializerListaAlumno.GuardarXML(@"alumno.xml", listaAlumnos))
            { Console.WriteLine("Serializado exitosamente"); */

            /*XML<List<Profesor>> serializerListaProfesor = new XML<List<Profesor>>();
            List<Profesor> listaProfesor = new List<Profesor>();
            listaProfesor.Add(profeA);
            listaProfesor.Add(profeB);
            listaProfesor.Add(profeC);

            if (serializerListaProfesor.GuardarXML(@"alumno.xml", listaProfesor))
            { Console.WriteLine("Serializado exitosamente"); */


            //XML<List<Persona>> serializerListaPersona = new XML<List<Persona>>();
            //List<Persona> listaPersona = new List<Persona>();
            //listaPersona.Add(alA);
            //listaPersona.Add(profeA);
            //listaPersona.Add(alC);

            //if (serializerListaPersona.GuardarXML(@"alumno.xml", listaPersona)) //Da excepction de generacion de archivo porque la variable de control es la clase base, y no irá a serializar las clases heradas, se arregla con [XMLInclude] 
            //{ Console.WriteLine("Serializado exitosamente"); }
            //else
            //{ Console.WriteLine("Serializacion sin exito"); }

            XML<Aula> serializerAula = new XML<Aula>();
            Aula aula2 = new Aula();

            if (serializerAula.GuardarXML(@"alumno.xml", aula1))
            { Console.WriteLine("Serializado exitosamente"); }
            else
            { Console.WriteLine("Serializacion sin exito"); }

            if (serializerAula.LeerXML(@"alumno.xml", out aula2))
            {
                Console.WriteLine("Deserializado exitosamente");
                Console.WriteLine(aula2.ToString());
            }

            Console.ReadLine();
        }

        public static Boolean GuardarXML(string path, Alumno alumnoAGuardar)
        {
            Boolean retorno = false;

            XmlTextWriter fileEncoding = new XmlTextWriter(path, Encoding.UTF8); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(Alumno)); //Para el tipo de objeto que se quiere serializar

            try
            {
                serializerXml.Serialize(fileEncoding, alumnoAGuardar); /*Se para el archivo que escribe (XmlTextWriter) y el objeto a serializar*/
                retorno = true;
            }
            catch (Exception) { }

            fileEncoding.Close();
            return retorno;
        }

        public static bool LeerXML(string path, out Alumno aRecuperar)
        {
            Boolean retorno = false;
            aRecuperar = new Alumno();

            XmlTextReader filePath = new XmlTextReader(path); //Path y juego de caracteres con el que se escribió
            XmlSerializer serializerXml = new XmlSerializer(typeof(Alumno));

            try
            {
                aRecuperar = ((Alumno)serializerXml.Deserialize(filePath));
                retorno = true;
            }
            catch (Exception)            { }

            filePath.Close();
            return retorno;
        }
    }

    interface algo<T>
    { void mostrar(T algo);}

    class a : algo<int>
    {
        void algo<int>.mostrar(int algo)
        {            Console.WriteLine(algo);        }
    }
}
