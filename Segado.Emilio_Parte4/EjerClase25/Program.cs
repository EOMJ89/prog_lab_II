using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Entidades.Alumnos;
using Entidades.Externa;
using Entidades.Externa.Sellada;


namespace EjerClase25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Clase Nro 25";
            Random r = new Random();

            #region "Instancias de Personas"
            Persona personaA1 = new Persona("Persona1", "TestA", r.Next(0, 100), Entidades.Alumnos.ESexo.Masculino);
            PersonaExterna personaB2 = new PersonaExterna("Persona2", "TextB", r.Next(0, 100), Entidades.Externa.ESexo.Indefinido);
            PersonaExternaDerivada personaC3 = new PersonaExternaDerivada("Persona3", "TestC", r.Next(0, 100), Entidades.Externa.ESexo.Femenino);
            PersonaExternaSellada personaD4 = new PersonaExternaSellada("Persona4", "TestD", r.Next(0, 100), Entidades.Externa.Sellada.ESexo.Masculino);
            PersonaExternaSellada personaE5 = new PersonaExternaSellada("Persona5", "TestE", r.Next(0, 100), Entidades.Externa.Sellada.ESexo.Masculino);
            #endregion

            #region "Mostrar con metodo de extensión"
            Console.WriteLine(personaA1.ObtenerInfo());
            Console.WriteLine(personaB2.ObtenerInfoExterna()); //No va a funcionar porque su clase no tiene una sobrecarga de metodo to string ni acceso a los atributos protegidos
            Console.WriteLine(personaC3.ObtenerInfoExternaDerivada()); //Tambien puede usar el de su clase base por más que no funcione
            Console.WriteLine(personaD4.ObtenerInfoDll());
            #endregion

            #region "Metodo de extensión para guardar en Archivo"
            if (personaA1.GuardaArchivo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\TestPersona.txt"))
            { Console.WriteLine("Guardado Completo"); }
            else
            { Console.WriteLine("Error en Guardado"); }
            #endregion

            #region "Metodo de extensión que verifica la nulidad de un objeto"
            if (personaA1.IsNull())
            { Console.WriteLine("Es Null"); }
            else
            { Console.WriteLine("No es Null"); }
            #endregion

            #region "Metodo de extensión que muestra la cantidad de caracteres de un string, primero muestra el resultado de un lenght normal"
            Console.WriteLine("Lenght regular: " + (personaB2.ToString()).Length);

            Console.WriteLine("Met. Extensión de Cantidad Caracteres: " + (personaB2.ToString()).CantidadCaracteres());
            #endregion

            #region "Metodo de extensión que agrega un registro a la base de datos"
            if (personaE5.AgregarBD())
            { Console.WriteLine("Agregado a BD"); }
            else
            { Console.WriteLine("Error al agregar a BD"); }
            #endregion

            #region "Metodo de extensíón que trae todos los registros desde una base de datos a una lista de PersonaExternaSellada"
            List<PersonaExternaSellada> lista = new List<PersonaExternaSellada>();
            lista.TraerPersonas();

            foreach (PersonaExternaSellada personaSA in lista)
            { Console.WriteLine(personaSA.ObtenerInfoDll()); }
            #endregion

            Console.ReadLine();
        }
    }
}
